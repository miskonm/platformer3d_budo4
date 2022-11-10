using Newtonsoft.Json;

namespace Services.Forecast
{
    public class ForecastDTO
    {
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("dt")]
        public long DateTimeSince;
        [JsonProperty("weather")]
        public WeatherDTO[] WeatherArray;
        [JsonProperty("main")]
        public MainDTO MainDTO;
        [JsonProperty("wind")]
        public WindDTO WindDTO;

        public override string ToString() =>
            $"Name '{Name}', DateTimeSince '{DateTimeSince}', WeatherArray '{WeatherArray}', MainDTO '{MainDTO}', " +
            $"WindDTO '{WindDTO}',";
    }
}