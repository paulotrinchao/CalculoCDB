namespace Domain.Interfaces
{
    public interface ICdbCalculator
    {
        decimal CalcularCDB(decimal valorMonetario, int prazoMeses);
    }
}
