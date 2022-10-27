using Zenject;

namespace Game.Systems.Enemy
{
    public class EnemyFactoryInstaller : Installer<EnemyFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
        }
    }
}