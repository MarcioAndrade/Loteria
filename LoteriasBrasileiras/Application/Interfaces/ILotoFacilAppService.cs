using Domain.LotoFacil;
using Application.ViewModel;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ILotoFacilAppService
    {
        IList<LotoFacilCEF> ImportarArquivo(string pathArquivo, int ultimoConcurso);
        IList<LotoFacilViewModel> ObterTodos();
        LotoFacilViewModel Obter(int concurso);
        int GravarSorteios(IList<LotoFacilCEF> sorteios);
        int Importar();
    }
}
