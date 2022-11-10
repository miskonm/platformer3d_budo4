using System;

namespace Services.Forecast
{
    public interface IForecastService
    {
        event Action OnReady;
        
        bool IsReady { get; }
        ForecastData Data { get; }

        
        void LoadData(Action completeCallback = null);
    }
}