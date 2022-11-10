using System;
using Services.Web;

namespace Services.Forecast
{
    public class ForecastDataMapper : BaseDataMapper<ForecastDTO, ForecastData>
    {
        public override ForecastData Map(ForecastDTO dto)
        {
            return new ForecastData()
            {
                CityName = dto.Name,
                TempInCelsius = KelvinToCelsius(dto.MainDTO.TempInKelvin),
                SeaLevel = dto.MainDTO.SeaLevel,
                WindSpeedInMeters = dto.WindDTO.SpeedInMeters,
                Date = DateTime.FromFileTimeUtc(dto.DateTimeSince) // TODO: Correct convertation
            };
        }

        private static float KelvinToCelsius(float kelvin) =>
            kelvin - 273.15f;
    }
}