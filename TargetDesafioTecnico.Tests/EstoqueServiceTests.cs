using TargetDesafioTecnico.Application.DTOs;
using TargetDesafioTecnico.Application.Services;

namespace TargetDesafioTecnico.Tests;

public class EstoqueServiceTests
{
    private readonly EstoqueService _service;
    public EstoqueServiceTests()
    {
        _service = new EstoqueService();
    }


    [Fact]
    public void ProcessarMovimentacao_Entrada_DeveAumentarEstoque()
    {
        var dto = new MovimentacaoEstoqueRequestDto
        {
            CodigoProduto = 101,
            Tipo = TipoMovimentacao.Entrada,
            Quantidade = 50,
            Descricao = "Entrada de estoque"
        };

        var resposta = _service.ProcessarMovimentacao(dto);

        Assert.Equal(150, resposta.EstoqueAnterior);
        Assert.Equal(200, resposta.EstoqueFinal);
    }

    [Fact]
    public void ProcessarMovimentacao_SaidaMaiorQueEstoque_DeveLancarExcecao()
    {
        var dto = new MovimentacaoEstoqueRequestDto
        {
            CodigoProduto = 102,
            Tipo = TipoMovimentacao.Saida,
            Quantidade = 900,
            Descricao = "Venda Excessiva"
        };
        
        Assert.Throws<InvalidOperationException>(() => _service.ProcessarMovimentacao(dto));
    }

}
