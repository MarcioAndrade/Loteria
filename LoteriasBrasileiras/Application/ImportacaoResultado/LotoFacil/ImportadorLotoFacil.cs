using System;
using AutoMapper;
using System.Linq;
using Domain.LotoFacil;
using Application.Util;
using Application.ViewModel;
using Application.Interfaces;
using System.Collections.Generic;
using Domain.LotoFacil.Repository;

namespace Application.ImportacaoResultado.LotoFacil
{
    public class ImportadorLotoFacil : ILotoFacilAppService
    {
        private readonly IMapper _mapper;
        private readonly ILotoFacilRepository _lotoFacilRepository;
        private readonly string pathArquivoZip = @"E:\Meus documentos\Projetos\Loteria\Resultados\";
        private readonly string arquivoZip = @"D_lotfac.zip";
        private readonly string extensaoArquivoHtm = @"D_LOTFAC.htm";
        private readonly string urlDownload = @"http://www1.caixa.gov.br/loterias/_arquivos/loterias/";

        public ImportadorLotoFacil(IMapper mapper, ILotoFacilRepository lotoFacilRepository)
        {
            _mapper = mapper;
            _lotoFacilRepository = lotoFacilRepository;
        }

        public string Importar()
        {
            var ultimo = _lotoFacilRepository.ObterUltimo();
            int ultimoConcurso = ultimo != null ? ultimo.Concurso : 0;

            ArquivoHelper.BaixarUltimoResultadoCEF(urlDownload, arquivoZip, pathArquivoZip);

            var pathArquivo = ArquivoHelper.UnzipArquivo(pathArquivoZip, arquivoZip, extensaoArquivoHtm);

            var informacoesArquivo = ArquivoHelper.ExtrairInformacoesArquivo(pathArquivo, 31);

            var sorteios = MontarSorteios(informacoesArquivo, ultimoConcurso);

            var importados = GravarSorteios(sorteios.Validos);

            if (importados == 0)
                return @"Nenhum jogo foi importado pois a base de dados já estava atualizada.";

            if (importados == 1)
                return @"Um jogo foi importado.";

            return string.Format("{0} jogos foram importados.", importados);
        }

        public Importacao MontarSorteios(List<List<string>> componentes, int? ultimoConcurso = 0)
        {
            var importacao = new Importacao();

            foreach (var item in componentes)
            {
                if (item.Any() && item.Count == 31)
                {
                    var concurso = Convert.ToInt32(item[0]);
                    if (concurso <= ultimoConcurso)
                        continue;
                    var dataSorteio = Convert.ToDateTime(item[1]);
                    var bola01 = Convert.ToInt32(item[2]);
                    var bola02 = Convert.ToInt32(item[3]);
                    var bola03 = Convert.ToInt32(item[4]);
                    var bola04 = Convert.ToInt32(item[5]);
                    var bola05 = Convert.ToInt32(item[6]);
                    var bola06 = Convert.ToInt32(item[7]);
                    var bola07 = Convert.ToInt32(item[8]);
                    var bola08 = Convert.ToInt32(item[9]);
                    var bola09 = Convert.ToInt32(item[10]);
                    var bola10 = Convert.ToInt32(item[11]);
                    var bola11 = Convert.ToInt32(item[12]);
                    var bola12 = Convert.ToInt32(item[13]);
                    var bola13 = Convert.ToInt32(item[14]);
                    var bola14 = Convert.ToInt32(item[15]);
                    var bola15 = Convert.ToInt32(item[16]);
                    var arrecadacao = Convert.ToDecimal(item[17]);
                    var ganhadores15 = Convert.ToInt32(item[18]);
                    var ganhadores14 = Convert.ToInt32(item[19]);
                    var ganhadores13 = Convert.ToInt32(item[20]);
                    var ganhadores12 = Convert.ToInt32(item[21]);
                    var ganhadores11 = Convert.ToInt32(item[22]);
                    var valorRateio15 = Convert.ToDecimal(item[23]);
                    var valorRateio14 = Convert.ToDecimal(item[24]);
                    var valorRateio13 = Convert.ToDecimal(item[25]);
                    var valorRateio12 = Convert.ToDecimal(item[26]);
                    var valorRateio11 = Convert.ToDecimal(item[27]);
                    var acumulado = Convert.ToDecimal(item[28]);
                    var estimativaPremio = Convert.ToDecimal(item[29]);
                    var acumuladoEspecial = Convert.ToDecimal(item[30]);

                    var resultadoCef = new LotoFacilCEF(
                        concurso, dataSorteio, bola01, bola02, bola03, bola04, bola05, bola06, bola07, bola08, bola09,
                        bola10, bola11, bola12, bola13, bola14, bola15, arrecadacao, ganhadores15, ganhadores14, ganhadores13, ganhadores12,
                        ganhadores11, valorRateio15, valorRateio14, valorRateio13, valorRateio12, valorRateio11, acumulado, estimativaPremio, acumuladoEspecial);

                    if (resultadoCef.EhValido())
                        importacao.Validos.Add(resultadoCef);
                    else
                        importacao.Rejeitados.Add(resultadoCef);
                }
            }

            return importacao;
        }

        public IList<LotoFacilViewModel> ObterTodos()
        {
            var resultados = _lotoFacilRepository.ObterTodos().ToList().OrderBy(c => c.Concurso);

            return _mapper.Map<IList<LotoFacilViewModel>>(resultados);

        }

        public LotoFacilViewModel Obter(int concurso)
        {
            var resultado = _lotoFacilRepository.Obter(concurso);

            return _mapper.Map<LotoFacilViewModel>(resultado);

        }

        public int GravarSorteios(IList<LotoFacilCEF> sorteios)
        {
            _lotoFacilRepository.Adicionar(sorteios);

            return _lotoFacilRepository.SaveChanges();
        }
    }
}
