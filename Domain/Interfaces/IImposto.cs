namespace Domain.Interfaces
{
    public interface IImposto
    {
        decimal ObterAliquota( int meses);
        decimal CalcularImposto(decimal valorBase, int meses);
    }
}
