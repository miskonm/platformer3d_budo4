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

    // "coord": {
    //     "lon": 27.5615,
    //     "lat": 53.9045
    // },
    // "weather": [
    // {
    //     "id": 804,
    //     "main": "Clouds",
    //     "description": "overcast clouds",
    //     "icon": "04n"
    // }
    // ],
    // "base": "stations",
    // "main": {
    //     "temp": 282.07,
    //     "feels_like": 279.49,
    //     "temp_min": 281.95,
    //     "temp_max": 282.07,
    //     "pressure": 1017,
    //     "humidity": 90,
    //     "sea_level": 1017,
    //     "grnd_level": 991
    // },
    // "visibility": 10000,
    // "wind": {
    //     "speed": 4.76,
    //     "deg": 229,
    //     "gust": 11.78
    // },
    // "clouds": {
    //     "all": 96
    // },
    // "dt": 1667924679,
    // "sys": {
    //     "type": 1,
    //     "id": 8939,
    //     "country": "BY",
    //     "sunrise": 1667884991,
    //     "sunset": 1667917430
    // },
    // "timezone": 10800,
    // "id": 625143,
    // "name": "Minsk City",
    // "cod": 200
}