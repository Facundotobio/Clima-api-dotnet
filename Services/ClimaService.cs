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

        public async Task<PronosticoClimaticoDto?> GetForecastAsync(string ciudad, int dias)
        {
            try
            {
                var json = await _apisExternas.ObtenerPronosticoAsync(ciudad, dias);

                if (string.IsNullOrWhiteSpace(json))
                    return null;

                var data = JsonConvert.DeserializeObject<PronosticoClimaticoDto>(json);
                return data;
            }
            catch (Exception)
            {
                throw new ApplicationException("Los datos ingresados son inválidos.");
            }
        }

    }
}
