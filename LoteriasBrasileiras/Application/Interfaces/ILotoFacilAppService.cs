using Domain.LotoFacil;
using Application.ViewModel;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ILotoFacilAppService
    {
        IList<LotoFacilCEF> ImportarArquivo(int ultimoConcurso);
        IList<LotoFacilViewModel> ObterTodos();
        int GravarSorteios(IList<LotoFacilCEF> sorteios);
        int Importar();
    }
}
