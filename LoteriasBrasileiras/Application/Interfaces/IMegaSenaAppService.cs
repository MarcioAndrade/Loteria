using Domain.MegaSena;
using Application.ViewModel;
using System.Collections.Generic;
using Application.ImportacaoResultado.MegaSena;

namespace Application.Interfaces
{
    public interface IMegaSenaAppService
    {
        Importacao MontarSorteios(List<List<string>> componentes, int? ultimoConcurso);
        IList<MegaSenaViewModel> ObterTodos();
        MegaSenaViewModel Obter(int concurso);
        int GravarSorteios(IList<MegaSenaCEF> sorteios);
        string Importar();
    }
}
