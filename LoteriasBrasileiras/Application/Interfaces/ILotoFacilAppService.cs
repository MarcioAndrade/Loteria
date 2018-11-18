using Domain.LotoFacil;
using Application.ViewModel;
using System.Collections.Generic;
using Application.ImportacaoResultado.LotoFacil;

namespace Application.Interfaces
{
    public interface ILotoFacilAppService
    {
        Importacao MontarSorteios(List<List<string>> componentes, int? ultimoConcurso);
        IList<LotoFacilViewModel> ObterTodos();
        LotoFacilViewModel Obter(int concurso);
        int GravarSorteios(IList<LotoFacilCEF> sorteios);
        string Importar();
    }
}
