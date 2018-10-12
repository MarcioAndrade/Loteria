using Domain.LotoFacil;
using Repository.Context;
using Domain.LotoFacil.Repository;

namespace Repository.Repository
{
    public class LotoFacilRepository : Repository<LotoFacilCEF>, ILotoFacilRepository
    {
        public LotoFacilRepository(LoteriaContext context) : base(context)
        {
        }
    }
}
