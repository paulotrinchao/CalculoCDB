using Domain.Services;

namespace Tests.Services
{
    public class FatorProviderTests
    {
        [Fact]
        public void CalcularFator_DeveRetornarValorCorreto()
        {
            // Arrange
            var fatorProvider = new FatorProvider();
            var expected = 1 + (0.009m * 1.08m);

            // Act
            var resultado = fatorProvider.CalcularFator();

            // Assert
            Assert.Equal(expected, resultado);
        }
    }
}
