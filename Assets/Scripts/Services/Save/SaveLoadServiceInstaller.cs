using Zenject;

namespace Services.Save
{
    public class SaveLoadServiceInstaller : Installer<SaveLoadServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
        }
    }
}