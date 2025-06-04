namespace Clima.API.Clients
{
    public class ApisExternas
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public ApisExternas(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<string> ObtenerPronosticoAsync(string ciudad, int dias)
        {
            var claveApi = _config["WeatherApi:ClaveApi"];
            var url = $"https://api.weatherapi.com/v1/forecast.json?key={claveApi}&q={ciudad}&days={dias}&lang=es";

            var respuesta = await _httpClient.GetAsync(url);

            if (!respuesta.IsSuccessStatusCode)
            {
                var error = await respuesta.Content.ReadAsStringAsync();
                throw new Exception($"Error al consultar WeatherAPI: {respuesta.StatusCode} - {error}");
            }

            return await respuesta.Content.ReadAsStringAsync();
        }
    }
}
