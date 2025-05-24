using Domain.DTOs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentabilidadeController(IRentabilidadeService rentabilidadeService, ILogger<RentabilidadeController> logger) : ControllerBase
    {
        private readonly IRentabilidadeService _rentabilidadeService = rentabilidadeService;
        private readonly ILogger<RentabilidadeController> _logger = logger;

        [HttpPost("cdb")]
        public IActionResult Calcular([FromBody] InvestimentoRequest request)
        {
            if (request.ValorMonetario <= 0 || request.PrazoMeses <= 1)
                return BadRequest("Valor monetário deve ser positivo e prazo mínimo de 2 meses.");
            try
            {
                var resultado = _rentabilidadeService.CalcularInvestimento(request);
                return Ok(resultado);

            }
            catch (Exception error)
            {
                _logger.LogError(error,"Falha na operação de Cálculo em {DataHora} - Request: {@Request}",
                                  DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),request);

                return BadRequest("Falha na operação! dados não processados.");
                
            }
        }
    }
}
