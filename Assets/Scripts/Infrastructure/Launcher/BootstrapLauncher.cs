using Services.Config;
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

        [Inject]
        public void Construct(IPersistenceService persistenceService, IConfigService configService,
            ISceneLoadingService sceneLoadingService)
        {
            _persistenceService = persistenceService;
            _configService = configService;
            _sceneLoadingService = sceneLoadingService;
        }

        protected override void Launch()
        {
            _persistenceService.Bootstrap();
            _configService.Bootstrap();

            _sceneLoadingService.Load(MenuLauncher.SceneName);
        }
    }
}