using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IJogo
    {
        IList<int> Dezenas { get; }
        int? Acertos { get; set; }
        string Premiacao { get; }
    }
}
