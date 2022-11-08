using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Services.Forecast
{
    public class ForecastUiWidget : MonoBehaviour
    {
        [SerializeField] private GameObject _innerContainer;
        [SerializeField] private Button _button;

        private IForecastService _forecastService;
        private bool _isShowed;

        [Inject]
        public void Construct(IForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        private void Start()
        {
            _button.onClick.AddListener(OnButtonClicked);
            OnForecastReady();
            _forecastService.OnReady += OnForecastReady;
        }

        private void OnDestroy()
        {
            _forecastService.OnReady -= OnForecastReady;
        }

        private void OnForecastReady()
        {
            _innerContainer.SetActive(_forecastService.IsReady);
        }

        private void OnButtonClicked()
        {
            _isShowed = !_isShowed;

            if (_isShowed)
                _forecastService.ShowScreen();
            else
                _forecastService.HideScreen();
        }
    }
}