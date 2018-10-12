using Domain.Interfaces;
using Repository.Context;

namespace Repository.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LoteriaContext _context;

        public UnitOfWork(LoteriaContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return rowsAffected;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
