using System;

namespace Services.Forecast
{
    public class ForecastService : IForecastService
    {
        private readonly ForecastWebModule _webModule;
        private readonly ForecastUiModule _uiModule;
        private readonly ForecastDataMapper _dataMapper;

        public ForecastService(ForecastWebModule webModule, ForecastUiModule uiModule, ForecastDataMapper dataMapper)
        {
            _webModule = webModule;
            _uiModule = uiModule;
            _dataMapper = dataMapper;
        }

        public event Action OnReady;

        public bool IsReady { get; private set; }

        private ForecastData Data { get; set; }

        public void LoadData(Action completeCallback)
        {
            _webModule.LoadData((isSuccess, dto) =>
            {
                if (isSuccess)
                {
                    Data = _dataMapper.Map(dto);
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

            _uiModule.ShowScreen(Data);
        }

        public void HideScreen()
        {
            if (!IsReady)
                return;

            _uiModule.HideScreen();
        }
    }
}