using System;
using AutoMapper;
using System.Linq;
using Domain.MegaSena;
using Application.Util;
using Application.ViewModel;
using Application.Interfaces;
using Domain.MegaSena.Repository;
using System.Collections.Generic;

namespace Application.ImportacaoResultado.MegaSena
{
    public class ImportadorMegaSena : IMegaSenaAppService
    {
        private readonly IMapper _mapper;
        private readonly IMegaSenaRepository _megaSenaRepository;
        private readonly string pathArquivoZip = @"E:\Meus documentos\Projetos\Loteria\Resultados\";
        private readonly string arquivoZip = @"D_megase.zip";
        private readonly string extensaoArquivoHtm = @"D_MEGA.htm";
        private readonly string urlDownload = @"http://www1.caixa.gov.br/loterias/_arquivos/loterias/";

        public ImportadorMegaSena(IMapper mapper, IMegaSenaRepository megaSenaRepository)
        {
            _mapper = mapper;
            _megaSenaRepository = megaSenaRepository;
        }

        public string Importar()
        {
            var ultimo = _megaSenaRepository.ObterUltimo();
            int ultimoConcurso = ultimo != null ? ultimo.Concurso : 0;

            ArquivoHelper.BaixarUltimoResultadoCEF(urlDownload, arquivoZip, pathArquivoZip);

            var pathArquivo = ArquivoHelper.UnzipArquivo(pathArquivoZip, arquivoZip, extensaoArquivoHtm);

            var informacoesArquivo = ArquivoHelper.ExtrairInformacoesArquivo(pathArquivo, 19);

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
                if (item.Any() && item.Count == 19)
                {
                    var concurso = Convert.ToInt32(item[0]);
                    if (concurso <= ultimoConcurso)
                        continue;
                    var dataSorteio = Convert.ToDateTime(item[1]);
                    var primeiraDezena = Convert.ToInt32(item[2]);
                    var segundaDezena = Convert.ToInt32(item[3]);
                    var terceiraDezena = Convert.ToInt32(item[4]);
                    var quartaDezena = Convert.ToInt32(item[5]);
                    var quintaDezena = Convert.ToInt32(item[6]);
                    var sextaDezena = Convert.ToInt32(item[7]);
                    var arrecadacao = Convert.ToDecimal(item[8]);
                    var ganhadoresSena = Convert.ToInt32(item[9]);
                    var rateioSena = Convert.ToDecimal(item[10]);
                    var ganhadoresQuina = Convert.ToInt32(item[11]);
                    var rateioQuina = Convert.ToDecimal(item[12]);
                    var ganhadoresQuadra = Convert.ToInt32(item[13]);
                    var rateioQuadra = Convert.ToDecimal(item[14]);
                    var acumulado = item[15].Equals("SIM") ? "SIM" : "NAO";
                    var valorAcumulado = Convert.ToDecimal(item[16]);
                    var estimativaPremio = Convert.ToDecimal(item[17]);
                    var acumuladoMegaDaVirada = Convert.ToDecimal(item[18]);

                    var resultadoCef = new MegaSenaCEF(
                        concurso, dataSorteio, primeiraDezena, segundaDezena, terceiraDezena, quartaDezena, quintaDezena, sextaDezena, arrecadacao, ganhadoresSena,
                        rateioSena, ganhadoresQuina, rateioQuina, ganhadoresQuadra, rateioQuadra, acumulado, valorAcumulado, estimativaPremio, acumuladoMegaDaVirada);

                    if (resultadoCef.EhValido())
                        importacao.Validos.Add(resultadoCef);

                    else
                        importacao.Rejeitados.Add(resultadoCef);
                }
            }

            return importacao;
        }

        public MegaSenaViewModel Obter(int concurso)
        {
            var resultado = _megaSenaRepository.Obter(concurso);

            return _mapper.Map<MegaSenaViewModel>(resultado);
        }

        public int GravarSorteios(IList<MegaSenaCEF> sorteios)
        {
            _megaSenaRepository.Adicionar(sorteios);

            return _megaSenaRepository.SaveChanges();
        }

        public IList<MegaSenaViewModel> ObterTodos()
        {
            var resultados = _megaSenaRepository.ObterTodos().ToList().OrderBy(c => c.Concurso);

            return _mapper.Map<IList<MegaSenaViewModel>>(resultados);
        }
    }
}
