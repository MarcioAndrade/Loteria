using Dapper;
using System.Linq;
using Domain.LotoFacil;
using Repository.Context;
using System.Collections.Generic;
using Domain.LotoFacil.Repository;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class LotoFacilRepository : Repository<LotoFacilCEF>, ILotoFacilRepository
    {
        public LotoFacilRepository(LoteriaContext context) : base(context)
        {
        }

        public IEnumerable<LotoFacilCEF> ObterUltimo()
        {
            var sql = @"SELECT * 
                        FROM loteria.lotofacilcef 
                        WHERE concurso = 
                            (
                                SELECT MAX(concurso) 
                                FROM loteria.lotofacilcef
                            )";

            var x = Db.Database.GetDbConnection().QueryFirstOrDefault<object>(sql);

            return Db.LotoFacilCEFs.ToList();
        }
    }
}
