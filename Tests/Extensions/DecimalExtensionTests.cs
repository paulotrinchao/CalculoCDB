using Domain.Extensions;

namespace Tests.Extensions
{
    public class DecimalExtensionTests
    {
        [Theory]
        [InlineData(123.4567, 2, 123.46)]
        [InlineData(123.454, 2, 123.45)]
        [InlineData(-123.4567, 2, -123.46)]
        [InlineData(1.005, 2, 1.00)] 
        [InlineData(1.015, 2, 1.02)]
        [InlineData(0.0, 2, 0.00)]
        public void Round_DeveArredondarCorretamente(decimal valor, int casas, decimal esperado)
        {
            // Act
            var resultado = valor.Round(casas);

            // Assert
            Assert.Equal(esperado, resultado);
        }
    }
}
