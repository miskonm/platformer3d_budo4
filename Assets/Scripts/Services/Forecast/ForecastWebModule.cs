using System;
using Services.Location;
using Services.Web;
using UnityEngine;

namespace Services.Forecast
{
    public class ForecastWebModule
    {
        private const string Tag = nameof(ForecastWebModule);

        private const string Path = "https://api.openweathermap.org/data/2.5/weather";
        private const string ApiKey = "4ca9fe0d6500ac208f05d5c0edb0cba9";

        private readonly ILocationService _locationService;
        private readonly IHttpWebRequestFactory _httpWebRequestFactory;

        public ForecastWebModule(ILocationService locationService, IHttpWebRequestFactory httpWebRequestFactory)
        {
            _httpWebRequestFactory = httpWebRequestFactory;
            _locationService = locationService;
        }

        public void LoadData(Action<bool, ForecastDTO> completedCallback)
        {
            if (!_locationService.IsValid)
            {
                completedCallback?.Invoke(false, null);
                return;
            }

            Coords coords = _locationService.Coords;
            Uri uri = new Uri(Path).SetQuery(
                ("lat", coords.Latitude.ToString()),
                ("lon", coords.Longitude.ToString()),
                ("appid", ApiKey)
            );

            _httpWebRequestFactory.Get<ForecastDTO>(uri,
                response => { completedCallback?.Invoke(response.IsSuccess, response.Dto); });
        }
    }
}