using Domain.DTOs;
using Domain.Interfaces;
using Domain.Services;
using Moq;

namespace Tests.Services
{
    public class RentabilidadeServiceTests
    {
        private readonly Mock<ICdbCalculator> _cdbCalculatorMock;
        private readonly Mock<IImposto> _impostoMock;
        private readonly RentabilidadeService _service;

        public RentabilidadeServiceTests()
        {
            _cdbCalculatorMock = new Mock<ICdbCalculator>();
            _impostoMock = new Mock<IImposto>();
            _service = new RentabilidadeService(_cdbCalculatorMock.Object, _impostoMock.Object);
        }

        [Fact]
        public void CalcularInvestimento_DeveCalcularValorBrutoLiquidoECobrarImposto()
        {
            // Arrange
            var request = new InvestimentoRequest(1000m, 12);
            decimal valorBruto = 1120.75m; 
            decimal imposto = 20.75m;      
            decimal valorLiquido = valorBruto - imposto;

            _cdbCalculatorMock
                .Setup(c => c.CalcularCDB(request.ValorMonetario, request.PrazoMeses))
                .Returns(valorBruto);

            _impostoMock
                .Setup(i => i.CalcularImposto(valorBruto - request.ValorMonetario, request.PrazoMeses))
                .Returns(imposto);

            // Act
            var response = _service.CalcularInvestimento(request);


            // Assert
            Assert.Equal(Math.Round(valorBruto, 2), response.ResultadoBruto);
            Assert.Equal(Math.Round(valorLiquido, 2), response.ResultadoLiquido);

        }
    }

}
