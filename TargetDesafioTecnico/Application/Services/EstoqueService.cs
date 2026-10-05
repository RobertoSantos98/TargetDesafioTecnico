using TargetDesafioTecnico.Application.DTOs;

namespace TargetDesafioTecnico.Application.Services
{
    public class EstoqueService
    {
        private readonly List<ProdutoDto> _produtos;
        private readonly object _lock = new();

        public EstoqueService()
        {
            _produtos = new List<ProdutoDto>
            {
                new() { CodigoProduto = 101, DescricaoProduto = "Caneta Azul", Estoque = 150 },
                new() { CodigoProduto = 102, DescricaoProduto = "Caderno Universitário", Estoque = 75 },
                new() { CodigoProduto = 103, DescricaoProduto = "Borracha Branca", Estoque = 200 },
                new() { CodigoProduto = 104, DescricaoProduto = "Lápis Preto HB", Estoque = 320 },
                new() { CodigoProduto = 105, DescricaoProduto = "Marcador de Texto Amarelo", Estoque = 90 }
            };
        }

        public List<ProdutoDto> ObterTodos()
        {
            lock (_lock)
            {
                return _produtos.ToList();
            }
        }

        public MovimentacaoEstoqueResponseDto ProcessarMovimentacao(MovimentacaoEstoqueRequestDto request)
        {
            if(request.Quantidade <= 0)
            {
                throw new ArgumentException("A quantidade deve ser maior que zero.");
            }

            lock (_lock)
            {
                var produto = _produtos.FirstOrDefault(p => p.CodigoProduto == request.CodigoProduto);

                if(produto == null)
                    throw new KeyNotFoundException($"Produto com código {request.CodigoProduto} não encontrado.");

                int estoqueAnterior = produto.Estoque;

                if(request.Tipo == TipoMovimentacao.Saida)
                {
                    if (request.Quantidade > produto.Estoque)
                        throw new InvalidOperationException("Não é possível realizar a saída. A quantidade solicitada é maior que o estoque disponível.");

                    produto.Estoque -= request.Quantidade;
                }
                else if(request.Tipo == TipoMovimentacao.Entrada)
                {
                    produto.Estoque += request.Quantidade;
                }
                else
                {
                    throw new ArgumentException("Tipo de movimentação inválido.");
                }

                return new MovimentacaoEstoqueResponseDto
                {
                    IdMovimentacao = Guid.NewGuid(),
                    CodigoProduto = produto.CodigoProduto,
                    DescricaoProduto = produto.DescricaoProduto,
                    Tipo = request.Tipo,
                    QuantidadeMovimentada = request.Quantidade,
                    EstoqueAnterior = estoqueAnterior,
                    EstoqueFinal = produto.Estoque,
                    Descricao = request.Descricao,
                    DataMovimentacao = DateTime.UtcNow
                };

            }




        }
    }
}
