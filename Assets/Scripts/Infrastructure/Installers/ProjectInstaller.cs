using Services.Assets;
using Services.Config;
using Services.Coroutine;
using Services.Location;
using Services.Persistence;
using Services.SceneLoading;
using Services.Web;
using Zenject;

namespace Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            PersistenceServiceInstaller.Install(Container);
            ConfigServiceInstaller.Install(Container);
            CoroutineRunnerInstaller.Install(Container);
            SceneLoadingServiceInstaller.Install(Container);
            AssetsServiceInstaller.Install(Container);
            LocationServiceInstaller.Install(Container);
            HttpWebRequestInstaller.Install(Container);
        }
    }
}