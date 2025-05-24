using Domain.Interfaces;

namespace Domain.Services
{
    public class FatorProvider : IFatorProvider
    {
        private const decimal CDI = 0.009m;
        private const decimal TB = 1.08m;
        public decimal CalcularFator()
        {
            return 1 + (CDI * TB);
        }
    }
}
