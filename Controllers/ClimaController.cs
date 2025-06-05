using Clima.API.Models;
using Clima.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clima.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClimaController : ControllerBase
    {
        private readonly IClimaService _climaService;

        public ClimaController(IClimaService climaService)
        {
            _climaService = climaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPronostico([FromQuery] string ciudad, [FromQuery] int dias)
        {
            if (string.IsNullOrWhiteSpace(ciudad))
                return BadRequest("Debe especificar una ciudad.");

            if (dias < 1 || dias > 14)
                return BadRequest("La cantidad de días a consultar debe estar entre 1 y 14.");

            try
            {
                var resultado = await _climaService.GetForecastAsync(ciudad, dias);
                if (resultado == null)
                    return NotFound("No se encontró información para el destino ingresado.");

                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("comparar")]
        public async Task<IActionResult> CompararPronostico([FromQuery] string ciudad1, [FromQuery] string ciudad2, [FromQuery] int dias)
        {
            if (string.IsNullOrWhiteSpace(ciudad1) || string.IsNullOrWhiteSpace(ciudad2))
                return BadRequest("Debe especificar ambas ciudades para comparar.");

            if (string.Equals(ciudad1.Trim(), ciudad2.Trim(), StringComparison.OrdinalIgnoreCase))
                return BadRequest("Los destinos a comparar no pueden ser iguales.");

            if (dias < 1 || dias > 14)
                return BadRequest("La cantidad de días debe estar entre 1 y 14.");

            try
            {
                var resultado1 = await _climaService.GetForecastAsync(ciudad1, dias);
                var resultado2 = await _climaService.GetForecastAsync(ciudad2, dias);

                if (resultado1 == null || resultado2 == null)
                    return NotFound("No se pudo obtener el pronóstico para una o ambas ciudades.");

                var comparacion = new ComparacionClimaDto
                {
                    Ciudad1 = resultado1,
                    Ciudad2 = resultado2
                };

                return Ok(comparacion);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
