using System;

namespace Services.Forecast
{
    public class ForecastService : IForecastService
    {
        private readonly ForecastWebModule _webModule;
        private readonly ForecastUiModule _uiModule;

        public ForecastService(ForecastWebModule webModule, ForecastUiModule uiModule)
        {
            _webModule = webModule;
            _uiModule = uiModule;
        }

        public event Action OnReady;

        public bool IsReady { get; private set; }
        
        private ForecastDTO Dto { get; set; }

        public void LoadData(Action completeCallback)
        {
            _webModule.LoadData((isSuccess, dto) =>
            {
                if (isSuccess)
                {
                    // TODO: Map data
                    Dto = dto;
                    IsReady = true;
                    OnReady?.Invoke();
                }

                completeCallback?.Invoke();
            });
        }

        public void ShowScreen()
        {
            if (!IsReady)
                return;

            _uiModule.ShowScreen(Dto);
        }

        public void HideScreen()
        {
            if (!IsReady)
                return;

            _uiModule.HideScreen();
        }
    }
}