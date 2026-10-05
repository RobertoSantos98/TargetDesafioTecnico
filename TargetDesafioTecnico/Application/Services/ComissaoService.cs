using TargetDesafioTecnico.Application.DTOs;

namespace TargetDesafioTecnico.Application.Services
{
    public class ComissaoService
    {
        public List<ComissaoVendedorDto> CacularComissoes(RequestVendasDto request)
        {
            return request.Vendas
                        .GroupBy(v => v.Vendedor)
                        .Select(g => new ComissaoVendedorDto
                        {
                            Vendedor = g.Key,
                            TotalVendido = g.Sum(v => v.Valor),
                            TotalComissao = g.Sum(v => CalcularItem(v.Valor))
                        }).ToList();
        }


        private static decimal CalcularItem(decimal valor)
            {
                if(valor < 100m)
                {
                    return 0m;
                }

                if (valor < 500m)
                {
                    return valor * 0.01m;
                }

                return valor * 0.05m;
            }
    }

}
