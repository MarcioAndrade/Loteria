using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ISorteio
    {
        IList<int> DezenasSorteadas { get; }
    }
}
