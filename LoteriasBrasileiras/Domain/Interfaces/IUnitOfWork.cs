using System;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
