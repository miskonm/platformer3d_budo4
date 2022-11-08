using UnityEngine;
using Zenject;

namespace Services.Forecast
{
    public class ForecastServiceInstaller : MonoInstaller
    {
        [SerializeField] private ForecastUiModuleSettings _moduleSettings;
        
        public override void InstallBindings()
        {
            Container.Bind<ForecastWebModule>().FromNewComponentOnNewGameObject().AsSingle();
            Container.Bind<IForecastService>().To<ForecastService>().AsSingle();

            Container.Bind<ForecastUiModule>().AsSingle();
            Container.BindInstance(_moduleSettings);
        }
    }
}