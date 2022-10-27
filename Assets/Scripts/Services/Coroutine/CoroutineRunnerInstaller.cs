using Zenject;

namespace Services.Coroutine
{
    public class CoroutineRunnerInstaller : Installer<CoroutineRunnerInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromNewComponentOnNewGameObject()
                .WithGameObjectName(nameof(CoroutineRunner))
                .AsSingle();
        }
    }
}