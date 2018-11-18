using System;
using System.IO;
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

            var jogos = ImportarArquivo(pathArquivo, ultimoConcurso);

            var importados = GravarSorteios(jogos);

            if (importados == 0)
                return @"Nenhum jogo foi importado pois a base de dados já estava atualizada.";

            if (importados == 1)
                return @"Um jogo foi importado.";

            return string.Format("{0} jogos foram importados.", importados);
        }

        public IList<LotoFacilCEF> ImportarArquivo(string pathArquivo, int ultimoConcurso)
        {
            var resultados = new List<LotoFacilCEF>();
            var sorteio = new List<string>();

            using (var arquivo = new StreamReader(pathArquivo))
            {
                string linha;

                while ((linha = arquivo.ReadLine()) != null)
                {
                    if (linha.StartsWith("<tr"))
                    {
                        linha = arquivo.ReadLine();
                        sorteio = new List<string>();
                        while ((linha = arquivo.ReadLine()) != null && linha != "</tr>" && !linha.StartsWith("<th"))
                        {
                            if (linha.StartsWith("<td "))
                            {
                                linha = linha.
                                    Replace("<td rowspan=\"", "").
                                    Replace("</td>", "").
                                    Replace(">", "");
                                linha = linha.Split("\"")[1];

                                if (linha != "&nbsp1")
                                    sorteio.Add(linha);
                            }
                        }

                        if (sorteio.Any() && sorteio.Count == 31)
                        {
                            var concurso = Convert.ToInt32(sorteio[0]);
                            if (concurso <= ultimoConcurso)
                                continue;
                            var dataSorteio = Convert.ToDateTime(sorteio[1]);
                            var bola01 = Convert.ToInt32(sorteio[2]);
                            var bola02 = Convert.ToInt32(sorteio[3]);
                            var bola03 = Convert.ToInt32(sorteio[4]);
                            var bola04 = Convert.ToInt32(sorteio[5]);
                            var bola05 = Convert.ToInt32(sorteio[6]);
                            var bola06 = Convert.ToInt32(sorteio[7]);
                            var bola07 = Convert.ToInt32(sorteio[8]);
                            var bola08 = Convert.ToInt32(sorteio[9]);
                            var bola09 = Convert.ToInt32(sorteio[10]);
                            var bola10 = Convert.ToInt32(sorteio[11]);
                            var bola11 = Convert.ToInt32(sorteio[12]);
                            var bola12 = Convert.ToInt32(sorteio[13]);
                            var bola13 = Convert.ToInt32(sorteio[14]);
                            var bola14 = Convert.ToInt32(sorteio[15]);
                            var bola15 = Convert.ToInt32(sorteio[16]);
                            var arrecadacao = Convert.ToDecimal(sorteio[17]);
                            var ganhadores15 = Convert.ToInt32(sorteio[18]);
                            var ganhadores14 = Convert.ToInt32(sorteio[19]);
                            var ganhadores13 = Convert.ToInt32(sorteio[20]);
                            var ganhadores12 = Convert.ToInt32(sorteio[21]);
                            var ganhadores11 = Convert.ToInt32(sorteio[22]);
                            var valorRateio15 = Convert.ToDecimal(sorteio[23]);
                            var valorRateio14 = Convert.ToDecimal(sorteio[24]);
                            var valorRateio13 = Convert.ToDecimal(sorteio[25]);
                            var valorRateio12 = Convert.ToDecimal(sorteio[26]);
                            var valorRateio11 = Convert.ToDecimal(sorteio[27]);
                            var acumulado = Convert.ToDecimal(sorteio[28]);
                            var estimativaPremio = Convert.ToDecimal(sorteio[29]);
                            var acumuladoEspecial = Convert.ToDecimal(sorteio[30]);

                            var resultadoCef = new LotoFacilCEF(
                                concurso, dataSorteio, bola01, bola02, bola03, bola04, bola05, bola06, bola07, bola08, bola09,
                                bola10, bola11, bola12, bola13, bola14, bola15, arrecadacao, ganhadores15, ganhadores14, ganhadores13, ganhadores12,
                                ganhadores11, valorRateio15, valorRateio14, valorRateio13, valorRateio12, valorRateio11, acumulado, estimativaPremio, acumuladoEspecial);

                            if (resultadoCef.EhValido())
                                resultados.Add(resultadoCef);
                        }
                    }
                }
            }

            return resultados;
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
