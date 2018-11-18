using Domain.MegaSena;
using Application.ViewModel;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IMegaSenaAppService
    {
        IList<MegaSenaCEF> ImportarArquivo(string pathArquivo, int ultimoConcurso);
        IList<MegaSenaViewModel> ObterTodos();
        MegaSenaViewModel Obter(int concurso);
        int GravarSorteios(IList<MegaSenaCEF> sorteios);
        string Importar();
    }
}
