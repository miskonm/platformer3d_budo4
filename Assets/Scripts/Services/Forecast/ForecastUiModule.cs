using UnityEngine;

namespace Services.Forecast
{
    public class ForecastUiModule
    {
        private readonly ForecastUiModuleSettings _settings;

        private ForecastScreen _screen;

        public ForecastUiModule(ForecastUiModuleSettings settings)
        {
            _settings = settings;
        }

        // public void ShowScreen(ForecastDTO dto)
        // {
        //     if (_screen == null)
        //         CreateScreen();
        //
        //     _screen.Setup(dto);
        //     _screen.gameObject.SetActive(true);
        // }
        
        public void ShowScreen(ForecastData data)
        {
            if (_screen == null)
                CreateScreen();

            _screen.Setup(data);
            _screen.gameObject.SetActive(true);
        }

        public void HideScreen()
        {
            if (_screen == null)
                return;
            
            _screen.gameObject.SetActive(false);
        }

        private void CreateScreen()
        {
            _screen = Object.Instantiate(_settings.ScreenPrefab);
        }
    }
}