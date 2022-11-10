using Services.Forecast.Ui;
using Services.UI;
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
        private IUiService _uiService;
        private bool _isShowed;

        [Inject]
        public void Construct(IForecastService forecastService, IUiService uiService)
        {
            _forecastService = forecastService;
            _uiService = uiService;
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
            {
                _uiService.ShowScreen<ForecastScreenController>();
            }
            else
            {
                _uiService.HideScreen<ForecastScreenController>();
            }
        }
    }
}