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

        public override IEnumerable<LotoFacilCEF> ObterTodos()
        {
            var sql = @"SELECT * 
                        FROM loteria.lotofacilcef 
                       ";

            return Db.Database.GetDbConnection().Query<LotoFacilCEF>(sql);
        }

        public LotoFacilCEF ObterUltimo()
        {
            var sql = @"SELECT * 
                        FROM loteria.lotofacilcef 
                        WHERE concurso = 
                            (
                                SELECT MAX(concurso) 
                                FROM loteria.lotofacilcef
                            )";

            return Db.Database.GetDbConnection().QueryFirstOrDefault<LotoFacilCEF>(sql);

        }

        public LotoFacilCEF Obter(int concurso)
        {
            return Db.LotoFacilCEFs.FirstOrDefault(c => c.Concurso == concurso);
        }
    }
}
