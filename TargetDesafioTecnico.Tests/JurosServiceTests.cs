using TargetDesafioTecnico.Application.DTOs;
using TargetDesafioTecnico.Application.Services;
using Xunit;

namespace TargetDesafioTecnico.Tests
{
    public class JurosServiceTests
    {
        private readonly JurosService _service;

        public JurosServiceTests()
        {
            _service = new JurosService();
        }

        [Fact]
        public void CalcularJuros_ComAtraso_DeveCalcularDoisEPontoCincoPorCentoAoDia()
        {
            // Arrange - Vencimento há 10 dias
            var request = new JurosRequestDto
            {
                Valor = 100.00m,
                DataVencimento = DateTime.Today.AddDays(-10)
            };

            // Act
            var resultado = _service.CalcularJuros(request);

            // Assert
            Assert.Equal(10, resultado.DiasAtraso);
            Assert.Equal(25.00m, resultado.ValorJuros); // 100 * (10 * 0.025)
            Assert.Equal(125.00m, resultado.ValorTotal);
        }

        [Fact]
        public void CalcularJuros_VencimentoHojeOuFuturo_NaoDeveCobrarJuros()
        {
            // Arrange - Vencimento amanhã
            var request = new JurosRequestDto
            {
                Valor = 500.00m,
                DataVencimento = DateTime.Today.AddDays(1)
            };

            // Act
            var resultado = _service.CalcularJuros(request);

            // Assert
            Assert.Equal(0, resultado.DiasAtraso);
            Assert.Equal(0.00m, resultado.ValorJuros);
            Assert.Equal(500.00m, resultado.ValorTotal);
        }
    }
}