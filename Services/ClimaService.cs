using Clima.API.Clients;
using Clima.API.Models;
using Newtonsoft.Json;

namespace Clima.API.Services
{
    public class ClimaService : IClimaService
    {
        private readonly ApisExternas _apisExternas;

        public ClimaService(ApisExternas apisExternas)
        {
            _apisExternas = apisExternas;
        }

        public async Task<PronosticoClimaticoDto> GetForecastAsync(string ciudad, int dias)
        {
            var json = await _apisExternas.ObtenerPronosticoAsync(ciudad, dias);
            var data = JsonConvert.DeserializeObject<PronosticoClimaticoDto>(json);
            return data!;
        }
    }
}
