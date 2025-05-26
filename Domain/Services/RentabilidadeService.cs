using Domain.DTOs;
using Domain.Extensions;
using Domain.Interfaces;

namespace Domain.Services
{
    public class RentabilidadeService(ICdbCalculator cdbCalculator, IImposto imposto) : IRentabilidadeService
    {
        private readonly ICdbCalculator _cdbCalculator = cdbCalculator;
        private readonly IImposto _imposto = imposto;

        public InvestimentoResponse CalcularInvestimento(InvestimentoRequest input)
        {
            var valorFinal = _cdbCalculator.CalcularCDB(input.ValorMonetario, input.PrazoMeses);
            var valorLiquido = valorFinal - _imposto.CalcularImposto((valorFinal - input.ValorMonetario), input.PrazoMeses);

            return new InvestimentoResponse(valorFinal.Round(2),valorLiquido.Round(2));
        }
    }
}
