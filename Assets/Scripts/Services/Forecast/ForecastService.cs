using System;

namespace Services.Forecast
{
    public class ForecastService : IForecastService
    {
        private readonly ForecastWebModule _webModule;
        private readonly ForecastDataMapper _dataMapper;

        public ForecastService(ForecastWebModule webModule, ForecastDataMapper dataMapper)
        {
            _webModule = webModule;
            _dataMapper = dataMapper;
        }

        public event Action OnReady;

        public bool IsReady { get; private set; }

        public ForecastData Data { get; private set; }

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
    }
}