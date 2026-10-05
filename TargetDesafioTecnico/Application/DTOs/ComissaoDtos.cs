namespace TargetDesafioTecnico.Application.DTOs
{

    public class VendaDto
    {
        public string Vendedor { get; set; } = string.Empty;
        public decimal Valor { get; set; }
    }
    public class RequestVendasDto
    {
        public List<VendaDto> Vendas { get; set; } = [];
    }

    public class ComissaoVendedorDto
    {
        public string Vendedor { get; set; } = string.Empty;
        public decimal TotalVendido { get; set; }
        public decimal TotalComissao { get; set; }

    }
}
