using Domain.LotoFacil;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ILotoFacilAppService
    {
        List<LotoFacilCEF> ImportarArquivo(int ultimoConcurso);
        List<LotoFacilCEF> ObterTodos();
        int GravarSorteios(List<LotoFacilCEF> sorteios);
        int Importar();
    }
}
