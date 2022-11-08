using Newtonsoft.Json;

namespace Services.Forecast
{
    public class WeatherDTO
    {
        [JsonProperty("main")]
        public string Description;

        public override string ToString() =>
            $"Description '{Description}'";
    }
}