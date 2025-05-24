using Domain.Interfaces;
using Domain.Services;
using Moq;

namespace Tests.Services
{
    public class CdbCalculatorTests
    {
       private const decimal Fator = 1 + (0.009m * 1.08m);
        private readonly Mock<IFatorProvider>  _fatorMock;
        private readonly CdbCalculator _cdbCalculator;
        public CdbCalculatorTests()
        {
          
            _fatorMock = new Mock<IFatorProvider>();
            _fatorMock.Setup(fp => fp.CalcularFator()).Returns(Fator);
            _cdbCalculator = new CdbCalculator(_fatorMock.Object);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        public void CalcularCDB_DeveLancarExcecao_SeValorMonetarioForMenorOuIgualAZero(decimal valorInvalido)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _cdbCalculator.CalcularCDB(valorInvalido, 12));            
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]       
        public void CalcularCDB_DeveLancarExcecao_SePrazoEmMesesForMenorOuIgualAUM(int prazoEmMeses)
        {
            // Arrange             
            decimal valorInicial = 1000;
          
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _cdbCalculator.CalcularCDB(valorInicial, prazoEmMeses));
        }

        [Theory]
         [InlineData(100.69877745521,6)]
         [InlineData(20450454.6784645431457,12)]
        //[InlineData(111.2342353, 11111)]
        public void CalcularCDB_DeveAplicarFatorCorretamente(decimal valorInicial, int meses)
        {
            // Arrange         
            decimal valorEsperado = valorInicial;
            for (int i = 0; i < meses; i++)
                valorEsperado *= Fator;

            // Act
            var resultado = _cdbCalculator.CalcularCDB(valorInicial, meses);

            // Assert
            Assert.Equal(valorEsperado, resultado);
            _fatorMock.Verify(fp => fp.CalcularFator(), Times.Once);
        }
    }
}
