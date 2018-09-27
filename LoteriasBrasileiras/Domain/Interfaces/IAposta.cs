using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IAposta
    {
        int Concurso { get; }
        IEnumerable<IJogo> Jogos { get; set; }
    }
}
