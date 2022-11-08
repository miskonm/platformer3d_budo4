using Newtonsoft.Json;

namespace Services.Forecast
{
    public class WindDTO
    {
        [JsonProperty("speed")]
        public float SpeedInMeters;

        public override string ToString() =>
            $"SpeedInMeters '{SpeedInMeters}'";
    }
}