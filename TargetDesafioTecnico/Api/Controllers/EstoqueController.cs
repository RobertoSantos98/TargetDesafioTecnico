using Microsoft.AspNetCore.Mvc;
using TargetDesafioTecnico.Application.DTOs;
using TargetDesafioTecnico.Application.Services;

namespace TargetDesafioTecnico.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly EstoqueService _service;
        public EstoqueController(EstoqueService service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult ObterEstoque()
        {
            var produtos = _service.ObterTodos();
            return Ok(produtos);
        }

        [HttpPost("movimentar")]
        public IActionResult Movimentar([FromBody] MovimentacaoEstoqueRequestDto request)
        {
            try
            {
                var resultado = _service.ProcessarMovimentacao(request);
                return Ok(resultado);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}
