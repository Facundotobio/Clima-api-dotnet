using Newtonsoft.Json;

namespace Clima.API.Models
{
    public class PronosticoClimaticoDto
    {
        [JsonProperty("location")]
        public LocalizacionDto Localizacion { get; set; }

        [JsonProperty("forecast")]
        public PronosticoDto Pronostico { get; set; }
    }

    public class LocalizacionDto
    {
        [JsonProperty("name")]
        public string Nombre { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("country")]
        public string Pais { get; set; }

        [JsonProperty("lat")]
        public double Latitud { get; set; }

        [JsonProperty("lon")]
        public double Longitud { get; set; }

        [JsonProperty("tz_id")]
        public string ZonaHoraria { get; set; }

        [JsonProperty("localtime")]
        public string HoraLocal { get; set; }
    }

    public class PronosticoDto
    {
        [JsonProperty("forecastday")]
        public List<PronosticoDiaDto> PronosticoDias { get; set; }
    }

    public class PronosticoDiaDto
    {
        [JsonProperty("date")]
        public string Fecha { get; set; }

        [JsonProperty("day")]
        public DiaDto Dia { get; set; }
    }

    public class DiaDto
    {
        [JsonProperty("maxtemp_c")]
        public double TempMaxC { get; set; }

        [JsonProperty("maxtemp_f")]
        public double TempMaxF { get; set; }

        [JsonProperty("mintemp_c")]
        public double TempMinC { get; set; }

        [JsonProperty("mintemp_f")]
        public double TempMinF { get; set; }

        [JsonProperty("avgtemp_c")]
        public double TempPromC { get; set; }

        [JsonProperty("avgtemp_f")]
        public double TempPromF { get; set; }

        [JsonProperty("avghumidity")]
        public int Humedad { get; set; }

        [JsonProperty("totalprecip_mm")]
        public double Precipitacion { get; set; }

        [JsonProperty("condition")]
        public CondicionDto Condicion { get; set; }
    }

    public class CondicionDto
    {
        [JsonProperty("text")]
        public string Descripcion { get; set; }

        [JsonProperty("icon")]
        public string Icono { get; set; }
    }
}
