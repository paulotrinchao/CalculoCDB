using Domain.Services;

namespace Tests.Services
{
    public class ImpostoTests
    {
        private readonly Imposto _imposto;

        public ImpostoTests()
        {
            _imposto = new Imposto();
        }

        [Theory]
        [InlineData(1, 0.225)]
        [InlineData(6, 0.225)]
        [InlineData(7, 0.20)]
        [InlineData(12, 0.20)]
        [InlineData(13, 0.175)]
        [InlineData(24, 0.175)]
        [InlineData(25, 0.15)]
        [InlineData(36, 0.15)]
        public void ObterAliquota_DeveRetornar_O_Esperado(int meses, decimal esperado)
        {
            var resultado = _imposto.ObterAliquota(meses);
            Assert.Equal(esperado, resultado);
        }

        [Theory]
        [InlineData(10.99845, 6, 2.47465125)]
        [InlineData(0.9853, 12, 0.197060)]
        [InlineData(156865.8974552123464518333388, 24, 27451.532054662100)]
        [InlineData(2354.547878799875451, 36, 353.1821818199820)]
        public void CalcularImposto_DeveRetornarImpostoCorreto(decimal valorBase, int meses, decimal valorEsperadoCentavos)
        {
            var resultado = _imposto.CalcularImposto(valorBase, meses);
            var valorEsperado = valorEsperadoCentavos;
            Assert.Equal(valorEsperado, resultado);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        public void CalcularImposto_DeveLancarArgumentOutOfRangeException_QuandoValorBaseInvalido(decimal valorBase)
        {
            // Arrange
            int meses = 12;

            // Act & Assert          
            Assert.Throws<ArgumentOutOfRangeException>(() => _imposto.CalcularImposto(valorBase, meses));

        }
    }
}
