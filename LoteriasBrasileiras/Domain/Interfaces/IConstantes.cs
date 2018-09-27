namespace Domain.Interfaces
{
    public interface IConstantes
    {
        int ValorMinimoDezena { get; }
        int ValorMaximoDezena { get; }
        int DezenasSorteadas { get; }
        int MinimoDezenasAposta { get; }
        int MaximoDezenasAposta { get; }
        string TipoJogo { get; }
    }
}
