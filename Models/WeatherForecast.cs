using Newtonsoft.Json;
using System;
using WeatherAndMoviesApp.Services;

namespace WeatherAndMoviesApp.Models
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class WeatherForecast
    {
        public DateTime Date => DateTime.Now;

        [JsonProperty("main.temp")]
        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [JsonProperty("weather[0].main")]
        public string Main { get; set; }

        [JsonProperty("weather[0].description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string City { get; set; }
    }
}
