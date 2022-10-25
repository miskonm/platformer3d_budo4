using Game.Systems.Enemy;
using Services.Config;
using Services.Persistence;
using Services.Save;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class TestGameEntryPoint : MonoBehaviour
    {
        [SerializeField] private EnemyFactory _enemyFactory;

        private void Start()
        {
            // TODO: Some magic
            Init();
            SpawnAllEnemies();
            LoadDataToAll();
        }

        private void Init()
        {
            PersistenceService.Instance.Bootstrap();
            ConfigService.Instance.Bootstrap();
        }

        private void SpawnAllEnemies()
        {
            LevelConfig levelConfig = ConfigService.Instance.GetLevelConfig(SceneManager.GetActiveScene().name);
            foreach (EnemySpawnData enemySpawnData in levelConfig.EnemiesSpawnData)
            {
                _enemyFactory.Create(enemySpawnData.Id, enemySpawnData.Type, enemySpawnData.Position);
            }
        }

        private void LoadDataToAll()
        {
            SaveLoadService.Instance.Load();
        }
    }
}