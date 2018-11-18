using System;
using System.IO;
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

            var jogos = ImportarArquivo(pathArquivo, ultimoConcurso);

            var importados = GravarSorteios(jogos);

            if (importados == 0)
                return @"Nenhum jogo foi importado pois a base de dados já estava atualizada.";

            if (importados == 1)
                return @"Um jogo foi importado.";

            return string.Format("{0} jogos foram importados.", importados);
        }

        public IList<MegaSenaCEF> ImportarArquivo(string pathArquivo, int ultimoConcurso)
        {
            var resultados = new List<MegaSenaCEF>();
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

                        if (sorteio.Any() && sorteio.Count == 19)
                        {
                            var concurso = Convert.ToInt32(sorteio[0]);
                            if (concurso <= ultimoConcurso)
                                continue;
                            var dataSorteio = Convert.ToDateTime(sorteio[1]);
                            var primeiraDezena = Convert.ToInt32(sorteio[2]);
                            var segundaDezena = Convert.ToInt32(sorteio[3]);
                            var terceiraDezena = Convert.ToInt32(sorteio[4]);
                            var quartaDezena = Convert.ToInt32(sorteio[5]);
                            var quintaDezena = Convert.ToInt32(sorteio[6]);
                            var sextaDezena = Convert.ToInt32(sorteio[7]);
                            var arrecadacao = Convert.ToDecimal(sorteio[8]);
                            var ganhadoresSena = Convert.ToInt32(sorteio[9]);
                            var rateioSena = Convert.ToDecimal(sorteio[10]);
                            var ganhadoresQuina = Convert.ToInt32(sorteio[11]);
                            var rateioQuina = Convert.ToDecimal(sorteio[12]);
                            var ganhadoresQuadra = Convert.ToInt32(sorteio[13]);
                            var rateioQuadra = Convert.ToDecimal(sorteio[14]);
                            var acumulado = sorteio[15].Equals("SIM") ? "SIM" : "NAO";
                            var valorAcumulado = Convert.ToDecimal(sorteio[16]);
                            var estimativaPremio = Convert.ToDecimal(sorteio[17]);
                            var acumuladoMegaDaVirada = Convert.ToDecimal(sorteio[18]);

                            var resultadoCef = new MegaSenaCEF(
                                concurso, dataSorteio, primeiraDezena, segundaDezena, terceiraDezena, quartaDezena, quintaDezena, sextaDezena, arrecadacao, ganhadoresSena,
                                rateioSena, ganhadoresQuina, rateioQuina, ganhadoresQuadra, rateioQuadra, acumulado, valorAcumulado, estimativaPremio, acumuladoMegaDaVirada);

                            if (resultadoCef.EhValido())
                                resultados.Add(resultadoCef);
                        }
                    }
                }
            }

            return resultados;
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
