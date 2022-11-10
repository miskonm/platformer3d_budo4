using Services.Assets;
using Services.UI;

namespace Services.Forecast.Ui
{
    public class ForecastScreenController : ScreenController<ForecastScreen>
    {
        private readonly IForecastService _forecastService;

        public ForecastScreenController(IAssetsService assetsService, IForecastService forecastService) : base(assetsService)
        {
            _forecastService = forecastService;
        }

        protected override void OnShowBegin()
        {
            base.OnShowBegin();
            
            Screen.Setup(_forecastService.Data);
        }
    }
}