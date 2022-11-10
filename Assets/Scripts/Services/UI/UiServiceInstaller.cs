using Zenject;

namespace Services.UI
{
    public class UiServiceInstaller : Installer<UiServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IUiService>()
                .FromSubContainerResolve()
                .ByMethod(InstallService)
                .AsSingle();
        }

        private void InstallService(DiContainer subContainer)
        {
            subContainer.Bind<IUiService>().To<UiService>().AsSingle();
            subContainer.Bind<UiFactory>().AsSingle();
        }
    }
}