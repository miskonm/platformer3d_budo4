using Services.Assets;
using Services.UI;
using UnityEngine;

namespace Services.Forecast.Ui
{
    public class ForecastScreenController : ScreenController<ForecastScreen>
    {
        private readonly IForecastService _forecastService;

        public ForecastScreenController(IForecastService forecastService, IAssetsService assetsService,
            Transform parentTransform) : base(assetsService, parentTransform)
        {
            _forecastService = forecastService;
        }

        protected override void OnShowBegin()
        {
            base.OnShowBegin();

            Screen.Setup(_forecastService.Data);
        }

        protected override void OnShowEnd()
        {
            base.OnShowEnd();

            Screen.OnTestButtonClicked += OnTestButtonClicked;
        }

        protected override void OnHideBegin()
        {
            Screen.OnTestButtonClicked -= OnTestButtonClicked;

            base.OnHideBegin();
        }

        private void OnTestButtonClicked()
        {
            _forecastService.LoadDataAsync(); // This is example
        }
    }
}