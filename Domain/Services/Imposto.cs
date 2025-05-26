using Domain.Exceptions;
using Domain.Interfaces;

namespace Domain.Services
{
    public class Imposto : IImposto
    {
      
        public decimal ObterAliquota(int meses) =>
                                                   meses switch
                                                   {
                                                       <= 6 => 0.225m,
                                                       <= 12 => 0.20m,
                                                       <= 24 => 0.175m,
                                                       _ => 0.15m
                                                   };

        public decimal CalcularImposto(decimal valorBase, int meses)
        {
            NumericExcecao.ThrowIfNegativeOrZero(nameof(valorBase), valorBase, "O valor deve ser maior que zero.");
           
            return (valorBase * ObterAliquota(meses));
        }
    }
  
}
