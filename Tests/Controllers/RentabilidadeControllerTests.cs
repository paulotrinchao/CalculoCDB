using Domain.DTOs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WebApi.Controllers;

namespace Tests.Controllers
{
    public class RentabilidadeControllerTests
    {
        private readonly Mock<IRentabilidadeService> _rentabilidadeServiceMock;
        private readonly Mock<ILogger<RentabilidadeController>> _loggerMok;
        private readonly RentabilidadeController _controller;

        public RentabilidadeControllerTests()
        {
            _rentabilidadeServiceMock = new Mock<IRentabilidadeService>();
            _loggerMok = new Mock<ILogger<RentabilidadeController>>();
            _controller = new RentabilidadeController(_rentabilidadeServiceMock.Object,_loggerMok.Object);
        }

        [Fact]
        public void Calcular_DeveRetornarBadRequest_SeValorOuPrazoInvalidos()
        {
            // Arrange
            var requestInvalido1 = new InvestimentoRequest(0, 12);
            var requestInvalido2 = new InvestimentoRequest(1000, 1);

            // Act
            var resultado1 = _controller.Calcular(requestInvalido1);
            var resultado2 = _controller.Calcular(requestInvalido2);

            // Assert
            Assert.IsType<BadRequestObjectResult>(resultado1);
            Assert.IsType<BadRequestObjectResult>(resultado2);

            var badRequest1 = resultado1 as BadRequestObjectResult;
            var badRequest2 = resultado2 as BadRequestObjectResult;
            Assert.Equal("Valor monetário deve ser positivo e prazo mínimo de 2 meses.", badRequest1!.Value);
            Assert.Equal("Valor monetário deve ser positivo e prazo mínimo de 2 meses.", badRequest2!.Value);

            _rentabilidadeServiceMock.Verify(s => s.CalcularInvestimento(It.IsAny<InvestimentoRequest>()), Times.Never);
        }

        [Fact]
        public void Calcular_DeveRetornarOk_QuandoRequestValido()
        {
            // Arrange
            var request = new InvestimentoRequest(1000, 12);
            var responseEsperado = new InvestimentoResponse(1120.75m, 1100.00m);

            _rentabilidadeServiceMock
                .Setup(s => s.CalcularInvestimento(request))
                .Returns(responseEsperado);

            // Act
            var resultado = _controller.Calcular(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(resultado);
            Assert.Equal(responseEsperado, okResult.Value);

            _rentabilidadeServiceMock.Verify(s => s.CalcularInvestimento(request), Times.Once);
        }
    }
}
