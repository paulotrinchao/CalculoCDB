using Domain.Exceptions;

namespace Tests.Exceptions
{

    public class NumericExcecaoTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void ThrowIfNegativeOrZero_DeveLancarExcecao_ParaValoresNegativosOuZero(int valor)
        {
            // Arrange
            string paramName = "valor";
            string message = "Valor inválido";

            // Act & Assert
            var excecao = Assert.Throws<ArgumentOutOfRangeException>(() =>
                NumericExcecao.ThrowIfNegativeOrZero(paramName, valor, message));

            Assert.Equal(paramName, excecao.ParamName);
            Assert.Equal(valor, excecao.ActualValue);
            Assert.Contains(message, excecao.Message);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        public void ThrowIfNegativeOrZero_NaoDeveLancarExcecao_ParaValoresPositivos(int valor)
        {
            // Arrange
            string paramName = "valor";
            string message = "Valor inválido";

            // Act & Assert
            var exception = Record.Exception(() =>
                NumericExcecao.ThrowIfNegativeOrZero(paramName, valor, message));

            Assert.Null(exception);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(5, 5)]
        public void ThrowIfLessThanOrEqual_DeveLancarExcecao_QuandoMenorOuIgual(int valor, int outro)
        {
            // Arrange
            string paramName = "valor";
            string message = "Valor deve ser maior que o outro";

            // Act & Assert
            var excecao = Assert.Throws<ArgumentOutOfRangeException>(() =>
                NumericExcecao.ThrowIfLessThanOrEqual(paramName, valor, outro, message));

            Assert.Equal(paramName, excecao.ParamName);
            Assert.Equal(valor, excecao.ActualValue);
            Assert.Contains(message, excecao.Message);
        }

        [Fact]
        public void ThrowIfLessThanOrEqual_NaoDeveLancarExcecao_QuandoMaior()
        {
            // Arrange
            int valor = 10;
            int outro = 5;
            string paramName = "valor";
            string message = "Valor deve ser maior que o outro";

            // Act & Assert
            var exception = Record.Exception(() =>
                NumericExcecao.ThrowIfLessThanOrEqual(paramName, valor, outro, message));

            Assert.Null(exception);
        }
    }
}
