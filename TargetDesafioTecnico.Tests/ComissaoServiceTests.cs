using TargetDesafioTecnico.Application.DTOs;
using TargetDesafioTecnico.Application.Services;

namespace TargetDesafioTecnico.Tests
{
    public class ComissaoServiceTests
    {
        private readonly ComissaoService _service;
        public ComissaoServiceTests()
        {
            _service = new ComissaoService();
        }


        [Fact]
        public void CalcularComissoes_DeveAplicarAliquotaCOrretaPorFaixaDeVenda()
        {
            var requisicao = new RequestVendasDto
            {
                Vendas = new List<VendaDto>
                {
                    new() { Vendedor = "João Silva", Valor = 90.00m },   // 0%  -> R$ 0.00
                    new() { Vendedor = "João Silva", Valor = 200.00m },  // 1%  -> R$ 2.00
                    new() { Vendedor = "João Silva", Valor = 1000.00m }  // 5%  -> R$ 50.00
                }
            };

            var resultado = _service.CacularComissoes(requisicao);

            Assert.Single(resultado);
            var joao = resultado.First(v => v.Vendedor == "João Silva");

            Assert.Equal(1290.00m, joao.TotalVendido);
            Assert.Equal(52.00m, joao.TotalComissao);
        }
    }
}