using Domain.Interfaces;

namespace Domain.MegaSena.Repository
{
    public interface IMegaSenaRepository : IRepository<MegaSenaCEF>
    {
        MegaSenaCEF ObterUltimo();
        MegaSenaCEF Obter(int concurso);
    }
}
