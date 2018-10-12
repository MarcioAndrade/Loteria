using System;
using System.IO;
using Domain.LotoFacil;
using System.Collections.Generic;

namespace Application.ImportacaoResultado.LotoFacil
{
    public class ImportadorLotoFacil
    {
        public List<LotoFacilCEF> ImportarArquivo(int ultimoConcurso)
        {
            var resultados = new List<LotoFacilCEF>();
            var mensagemLinha = new List<string>();

            using (var arquivo = new StreamReader("C:\\Users\\Marcio\\Desktop\\D_LOTFAC.HTM"))
            {
                string mensagem;

                while ((mensagem = arquivo.ReadLine()) != null)
                {
                    if (mensagem.StartsWith("<tr"))
                    {
                        mensagemLinha = new List<string>();
                        while ((mensagem = arquivo.ReadLine()) != null)
                        {
                            if (mensagem != string.Empty && !mensagem.StartsWith("</tr") && mensagem.StartsWith("<td rowspan="))
                            {
                                mensagem = mensagem.Replace("<td rowspan=\"5\">", "").Replace("</td>", "");
                                mensagemLinha.Add(mensagem);
                            }

                            if (mensagem != string.Empty && mensagem.StartsWith("</tr") && mensagemLinha.Count > 29)
                            {
                                var concurso = Convert.ToInt32(mensagemLinha[0]);
                                var dataSorteio = Convert.ToDateTime(mensagemLinha[1]);
                                var bola01 = Convert.ToInt32(mensagemLinha[2]);
                                var bola02 = Convert.ToInt32(mensagemLinha[3]);
                                var bola03 = Convert.ToInt32(mensagemLinha[4]);
                                var bola04 = Convert.ToInt32(mensagemLinha[5]);
                                var bola05 = Convert.ToInt32(mensagemLinha[6]);
                                var bola06 = Convert.ToInt32(mensagemLinha[7]);
                                var bola07 = Convert.ToInt32(mensagemLinha[8]);
                                var bola08 = Convert.ToInt32(mensagemLinha[9]);
                                var bola09 = Convert.ToInt32(mensagemLinha[10]);
                                var bola10 = Convert.ToInt32(mensagemLinha[11]);
                                var bola11 = Convert.ToInt32(mensagemLinha[12]);
                                var bola12 = Convert.ToInt32(mensagemLinha[13]);
                                var bola13 = Convert.ToInt32(mensagemLinha[14]);
                                var bola14 = Convert.ToInt32(mensagemLinha[15]);
                                var bola15 = Convert.ToInt32(mensagemLinha[16]);
                                var arrecadacao = Convert.ToDecimal(mensagemLinha[17]);
                                var ganhadores15 = Convert.ToInt32(mensagemLinha[18]);
                                var ganhadores14 = Convert.ToInt32(mensagemLinha[19]);
                                var ganhadores13 = Convert.ToInt32(mensagemLinha[20]);
                                var ganhadores12 = Convert.ToInt32(mensagemLinha[21]);
                                var ganhadores11 = Convert.ToInt32(mensagemLinha[22]);
                                var valorRateio15 = Convert.ToDecimal(mensagemLinha[23]);
                                var valorRateio14 = Convert.ToDecimal(mensagemLinha[24]);
                                var valorRateio13 = Convert.ToDecimal(mensagemLinha[25]);
                                var valorRateio12 = Convert.ToDecimal(mensagemLinha[26]);
                                var valorRateio11 = Convert.ToDecimal(mensagemLinha[27]);
                                var acumulado = Convert.ToDecimal(mensagemLinha[28]);
                                var estimativaPremio = Convert.ToDecimal(mensagemLinha[29]);
                                var acumuladoEspecial = Convert.ToDecimal(mensagemLinha[30]);

                                var resultadoCef = new LotoFacilCEF(
                                    concurso, dataSorteio, bola01, bola02, bola03, bola04, bola05, bola06, bola07, bola08, bola09,
                                    bola10, bola11, bola12, bola13, bola14, bola15, arrecadacao, ganhadores15, ganhadores14, ganhadores13, ganhadores12,
                                    ganhadores11, valorRateio15, valorRateio14, valorRateio13, valorRateio12, valorRateio11, acumulado, estimativaPremio, acumuladoEspecial);

                                if (concurso > ultimoConcurso && resultadoCef.EhValido())
                                    resultados.Add(resultadoCef);
                            }
                        }
                    }

                }
            }

            return resultados;
        }
    }
}
