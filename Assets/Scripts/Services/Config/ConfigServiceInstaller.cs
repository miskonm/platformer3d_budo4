using Zenject;

namespace Services.Config
{
    public class ConfigServiceInstaller : Installer<ConfigServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IConfigService>().To<ConfigService>().AsSingle();
        }
    }
}