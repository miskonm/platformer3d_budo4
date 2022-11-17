using UnityEngine;
using Zenject;

namespace Services.Audio
{
    public class AudioServiceInstaller : MonoInstaller
    {
        [SerializeField] private Transform _parent;

        public override void InstallBindings()
        {
            Container
                .Bind<IAudioService>()
                .FromSubContainerResolve()
                .ByMethod(InitService)
                .AsSingle();
        }

        private void InitService(DiContainer subContainer)
        {
            subContainer.Bind<IAudioService>().To<AudioService>().AsSingle();
            subContainer.Bind<AudioPool>().AsSingle().WithArguments(_parent);
            subContainer.Bind<AudioGroupMapper>().AsSingle();

            subContainer.Bind<AudioGroup>().To<BackgroundAudioGroup>().AsSingle();
            subContainer.Bind<AudioGroup>().To<SfxAudioGroup>().AsSingle();
        }
    }
}