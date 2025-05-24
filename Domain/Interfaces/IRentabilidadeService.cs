using Domain.DTOs;

namespace Domain.Interfaces
{
    public interface IRentabilidadeService
    {
        InvestimentoResponse CalcularInvestimento(InvestimentoRequest input);
    }
}
