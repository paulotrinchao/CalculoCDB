using Domain.Interfaces;

namespace Domain.Services
{
    public class CdbCalculator(IFatorProvider fatorProvider) : ICdbCalculator
    {
     
        private readonly IFatorProvider _fatorProvider = fatorProvider;

        public decimal CalcularCDB(decimal valorMonetario, int prazoMeses)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(valorMonetario, "O valor monetário deve ser maior que zero.");
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(prazoMeses, 1 , "O prazo em meses deve ser maior que 1");

            var fator = _fatorProvider.CalcularFator();

            var valorFinal = valorMonetario;

            for (int i = 0; i < prazoMeses; i++)
            {
                valorFinal *= fator;
            }

            return valorFinal;
        }
    }
   

}
