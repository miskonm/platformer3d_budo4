using Game.Systems.Enemy;
using Services.Config;
using Services.Save;
using Services.SceneLoading;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure.Launcher
{
    public class GameLauncher : BaseLauncher
    {
        public const string SceneName = SceneNames.Game;

        private IConfigService _configService;
        private IEnemyFactory _enemyFactory;
        private ISaveLoadService _saveLoadService;

        [Inject]
        public void Construct(IConfigService configService, IEnemyFactory enemyFactory,
            ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            _enemyFactory = enemyFactory;
            _configService = configService;
        }

        protected override void Launch()
        {
            CreateEnemySpawners();
            LoadDataToAll();

            IsReady = true;
        }

        private void CreateEnemySpawners()
        {
            LevelConfig levelConfig = _configService.GetLevelConfig(SceneManager.GetActiveScene().name);
            foreach (EnemySpawnData enemySpawnData in levelConfig.EnemiesSpawnData)
                _enemyFactory.CreateSpawner(enemySpawnData.Id, enemySpawnData.Type, enemySpawnData.Position);
        }

        private void LoadDataToAll() =>
            _saveLoadService.Load();
    }
}