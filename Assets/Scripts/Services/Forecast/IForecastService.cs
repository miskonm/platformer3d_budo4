using System;
using Cysharp.Threading.Tasks;

namespace Services.Forecast
{
    public interface IForecastService
    {
        event Action OnReady;
        
        bool IsReady { get; }
        ForecastData Data { get; }
        
        UniTask LoadDataAsync();
    }
}