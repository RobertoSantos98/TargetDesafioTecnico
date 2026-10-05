using Microsoft.AspNetCore.Mvc;
using TargetDesafioTecnico.Application.DTOs;
using TargetDesafioTecnico.Application.Services;

namespace TargetDesafioTecnico.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JurosController : ControllerBase
    {
        private readonly JurosService _jurosService;
        public JurosController(JurosService jurosService)
        {
            _jurosService = jurosService;
        }



        [HttpPost("calcular")]
        public IActionResult CalcularJuros([FromBody] JurosRequestDto request)
        {
            try
            {
                var response = _jurosService.CalcularJuros(request);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }

        }
    }
}
