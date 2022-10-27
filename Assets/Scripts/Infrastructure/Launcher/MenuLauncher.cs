using Services.SceneLoading;
using UnityEngine;
using Zenject;

namespace Infrastructure.Launcher
{
    public class MenuLauncher : BaseLauncher
    {
        public const string SceneName = SceneNames.MenuScene;
        
        private ISceneLoadingService _sceneLoadingService;

        [Inject]
        public void Construct(ISceneLoadingService sceneLoadingService)
        {
            _sceneLoadingService = sceneLoadingService;
        }
        
        protected override void Launch()
        {
            _sceneLoadingService.SetLauncher(this);
            
            IsReady = true;
        }
    }
}