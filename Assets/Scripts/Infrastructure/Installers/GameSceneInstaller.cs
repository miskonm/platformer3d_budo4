using Game.Systems.Enemy;
using Game.Systems.Pause;
using Services.Save;
using Zenject;

namespace Infrastructure.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SaveLoadServiceInstaller.Install(Container);
            EnemyFactoryInstaller.Install(Container);
            PauseServiceInstaller.Install(Container);
        }
    }
}