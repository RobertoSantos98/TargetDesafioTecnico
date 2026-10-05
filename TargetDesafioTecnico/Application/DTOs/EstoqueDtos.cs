namespace TargetDesafioTecnico.Application.DTOs
{

    public enum TipoMovimentacao
    {
        Entrada = 1,
        Saida = 2
    }


    public class ProdutoDto
    {
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; } = string.Empty;
        public int Estoque { get; set; }
    }

    public class MovimentacaoEstoqueRequestDto
    {
        public int CodigoProduto { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public int Quantidade { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }

    public class MovimentacaoEstoqueResponseDto
    {
        public Guid IdMovimentacao { get; set; }
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; } = string.Empty;
        public TipoMovimentacao Tipo { get; set; }
        public int QuantidadeMovimentada { get; set; }
        public int EstoqueAnterior { get; set; }
        public int EstoqueFinal { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataMovimentacao { get; set; }
    }
}
