using Zenject;

namespace Services.SceneLoading
{
    public class SceneLoadingServiceInstaller : Installer<SceneLoadingServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneLoadingService>().To<SceneLoadingService>().AsSingle();
        }
    }
}