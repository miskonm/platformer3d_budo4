using UnityEngine;
using Zenject;

namespace Services.UI
{
    public class UiServiceInstaller : MonoInstaller
    {
        [SerializeField] private Transform _parentTransform;
        
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
            subContainer
                .Bind<IUiService>()
                .To<UiService>()
                .AsSingle()
                .WithArguments(_parentTransform);
            
            subContainer.Bind<UiFactory>().AsSingle();
        }
    }
}