using Dapper;
using System.Linq;
using Domain.MegaSena;
using Repository.Context;
using System.Collections.Generic;
using Domain.MegaSena.Repository;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class MegaSenaRepository : Repository<MegaSenaCEF>, IMegaSenaRepository
    {
        public MegaSenaRepository(LoteriaContext context) : base(context)
        {
        }

        public override IEnumerable<MegaSenaCEF> ObterTodos()
        {
            var sql = @"SELECT * 
                        FROM loteria.megasenacef 
                       ";

            return Db.Database.GetDbConnection().Query<MegaSenaCEF>(sql);
        }

        public MegaSenaCEF Obter(int concurso)
        {
            return Db.MegaSenaCEFs.FirstOrDefault(c => c.Concurso == concurso);
        }

        public MegaSenaCEF ObterUltimo()
        {
            var sql = @"SELECT * 
                        FROM loteria.megasenacef 
                        WHERE concurso = 
                            (
                                SELECT MAX(concurso) 
                                FROM loteria.megasenacef
                            )";

            return Db.Database.GetDbConnection().QueryFirstOrDefault<MegaSenaCEF>(sql);
        }
    }
}
