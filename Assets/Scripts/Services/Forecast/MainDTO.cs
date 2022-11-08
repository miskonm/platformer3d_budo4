using Newtonsoft.Json;

namespace Services.Forecast
{
    public class MainDTO
    {
        [JsonProperty("temp")]
        public float TempInKelvin;
        [JsonProperty("sea_level")]
        public int SeaLevel;
        [JsonProperty("pressure")]
        public int Pressure;

        public override string ToString() =>
            $"Pressure '{Pressure}', TempInKelvin '{TempInKelvin}', SeaLevel '{SeaLevel}'";
    }
}