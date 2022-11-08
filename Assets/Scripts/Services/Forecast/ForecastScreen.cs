using TMPro;
using UnityEngine;

namespace Services.Forecast
{
    public class ForecastScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _cityLabel;
        [SerializeField] private TextMeshProUGUI _tempLabel;
        [SerializeField] private TextMeshProUGUI _windLabel;
        [SerializeField] private TextMeshProUGUI _dateLabel;
        [SerializeField] private TextMeshProUGUI _seaLevelLabel;

        public void Setup(ForecastDTO dto)
        {
            _cityLabel.text = $"{dto.Name}";
            _tempLabel.text = $"Temp: {dto.MainDTO.TempInKelvin} K";
            _windLabel.text = $"Wind: {dto.WindDTO.SpeedInMeters} m/s";
            _dateLabel.text = $"Date: {dto.DateTimeSince}";
            _seaLevelLabel.text = $"Sea level: {dto.MainDTO.SeaLevel}";
        }
    }
}