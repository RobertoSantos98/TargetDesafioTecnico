using Microsoft.AspNetCore.Mvc;
using TargetDesafioTecnico.Application.DTOs;
using TargetDesafioTecnico.Application.Services;

namespace TargetDesafioTecnico.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComissaoController : ControllerBase
    {
        private readonly ComissaoService _service;
        public ComissaoController(ComissaoService service)
        {
            _service = service;
        }

        [HttpPost("calcular")]
        public IActionResult CalcularComissao([FromBody] RequestVendasDto request)
        {
            if(request?.Vendas == null || !request.Vendas.Any())
            {
                return BadRequest(new { message = "A lista de vendas não pode estar vazia." });
            }

            var resultado = _service.CacularComissoes(request);
            return Ok(resultado);
        }
    }
}
