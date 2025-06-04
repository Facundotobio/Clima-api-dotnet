using Newtonsoft.Json;

namespace Clima.API.Models
{
    public class ComparacionClimaDto
    {
        [JsonProperty("ciudad1")]
        public PronosticoClimaticoDto Ciudad1 { get; set; }

        [JsonProperty("ciudad2")]
        public PronosticoClimaticoDto Ciudad2 { get; set; }
    }
}
