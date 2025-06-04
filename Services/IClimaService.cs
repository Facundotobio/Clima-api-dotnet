using Clima.API.Models;

namespace Clima.API.Services
{
    public interface IClimaService
    {
        Task<PronosticoClimaticoDto> GetForecastAsync(string ciudad, int dias);
    }
}
