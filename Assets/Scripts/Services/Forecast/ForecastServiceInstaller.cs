using Zenject;

namespace Services.Forecast
{
    public class ForecastServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IForecastService>()
                .FromSubContainerResolve()
                .ByMethod(InstallService)
                .AsSingle();
        }

        private void InstallService(DiContainer subContainer)
        {
            subContainer.Bind<IForecastService>().To<ForecastService>().AsSingle();

            subContainer.Bind<ForecastWebModule>().AsSingle();
            subContainer.Bind<ForecastDataMapper>().AsSingle();
        }
    }
}