using System;

namespace Services.Forecast
{
    public interface IForecastService
    {
        event Action OnReady;
        
        bool IsReady { get; }
        
        void LoadData(Action completeCallback = null);

        // TODO: Remove
        void ShowScreen();
        void HideScreen();
    }
}