using Services.UI;
using TMPro;
using UnityEngine;

namespace Services.Forecast.Ui
{
    public class ForecastScreen : BaseScreen
    {
        [SerializeField] private TextMeshProUGUI _cityLabel;
        [SerializeField] private TextMeshProUGUI _tempLabel;
        [SerializeField] private TextMeshProUGUI _windLabel;
        [SerializeField] private TextMeshProUGUI _dateLabel;
        [SerializeField] private TextMeshProUGUI _seaLevelLabel;
        
        public void Setup(ForecastData data)
        {
            _cityLabel.text = $"{data.CityName}";
            _tempLabel.text = $"Temp: {data.TempInCelsius} C";
            _windLabel.text = $"Wind: {data.WindSpeedInMeters} m/s";
            _dateLabel.text = $"Date: {data.Date}";
            _seaLevelLabel.text = $"Sea level: {data.SeaLevel}";
        }
    }
}