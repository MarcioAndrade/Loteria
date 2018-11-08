using Domain.Interfaces;
using System.Collections.Generic;

namespace Domain.LotoFacil.Repository
{
    public interface ILotoFacilRepository : IRepository<LotoFacilCEF>
    {
        IEnumerable<LotoFacilCEF> ObterUltimo();
    }
}
