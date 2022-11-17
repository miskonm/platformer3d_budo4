using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Services.Audio;
using Services.Config;
using Services.Forecast;
using Services.Location;
using Services.Persistence;
using Services.SceneLoading;
using UnityEngine;
using Zenject;

namespace Infrastructure.Launcher
{
    public class BootstrapLauncher : BaseLauncher
    {
        private IPersistenceService _persistenceService;
        private IConfigService _configService;
        private ISceneLoadingService _sceneLoadingService;
        private IForecastService _forecastService;
        private ILocationService _locationService;
        private IAudioService _audioService;

        [Inject]
        public void Construct(IPersistenceService persistenceService, IConfigService configService,
            ISceneLoadingService sceneLoadingService, IForecastService forecastService,
            ILocationService locationService, IAudioService audioService)
        {
            _audioService = audioService;
            _locationService = locationService;
            _forecastService = forecastService;
            _persistenceService = persistenceService;
            _configService = configService;
            _sceneLoadingService = sceneLoadingService;
        }

        protected override void Launch()
        {
            LaunchAsync();
            Debug.LogError("IJIJIJIJIJ");
        }

        private async void LaunchAsync()
        {
            _persistenceService.Bootstrap();
            _configService.Bootstrap();
            _audioService.Bootstrap();
            
            await _locationService.BootstrapAsync();
            await _forecastService.LoadDataAsync();

            OnForecastLoaded();
        }

        private void OnForecastLoaded()
        {
            _sceneLoadingService.Load(MenuLauncher.SceneName);
        }
    }
}