using Zenject;

namespace Services.Persistence
{
    public class PersistenceServiceInstaller : Installer<PersistenceServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IPersistenceService>().To<PersistenceService>().AsSingle();
        }
    }
}