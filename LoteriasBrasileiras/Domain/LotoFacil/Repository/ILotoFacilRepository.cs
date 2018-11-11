using Domain.Interfaces;

namespace Domain.LotoFacil.Repository
{
    public interface ILotoFacilRepository : IRepository<LotoFacilCEF>
    {
        LotoFacilCEF ObterUltimo();
        LotoFacilCEF Obter(int concurso);
    }
}
