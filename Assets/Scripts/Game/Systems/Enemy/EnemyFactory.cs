using Game.Enemy;
using Services.Assets;
using Services.Config;
using Services.Save;
using UnityEngine;

namespace Game.Systems.Enemy
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IConfigService _configService;
        private readonly IAssetsService _assetsService;
        private readonly ISaveLoadService _saveLoadService;

        public EnemyFactory(IConfigService configService, IAssetsService assetsService,
            ISaveLoadService saveLoadService)
        {
            _configService = configService;
            _assetsService = assetsService;
            _saveLoadService = saveLoadService;
        }

        public GameObject CreateEnemy(EnemyType enemyType, Vector3 position)
        {
            EnemyConfig enemyConfig = _configService.GetEnemyConfig(enemyType);
            GameObject enemy = Object.Instantiate(enemyConfig.Prefab, position, Quaternion.identity);
            EnemyHp enemyHp = enemy.GetComponent<EnemyHp>();
            enemyHp.Current = enemyConfig.CurrentHp;
            enemyHp.Max = enemyConfig.MaxHp;
            return enemy;
        }

        public GameObject CreateSpawner(string id, EnemyType enemyType, Vector3 position)
        {
            GameObject spawnerPrefab = _assetsService.Load<GameObject>(AssetPath.EnemySpawner);
            EnemySpawner spawner =
                Object.Instantiate(spawnerPrefab, position, Quaternion.identity).GetComponent<EnemySpawner>();
            spawner.Construct(this);
            spawner.SetId(id);
            spawner.SetEnemyType(enemyType);

            Register(spawner.gameObject);

            return spawner.gameObject;
        }

        private void Register(GameObject go)
        {
            ISaveLoadDataPiece[] saveLoadDataPieces = go.GetComponentsInChildren<ISaveLoadDataPiece>();

            foreach (ISaveLoadDataPiece saveLoadDataPiece in saveLoadDataPieces)
                _saveLoadService.AddSaveLoadPiece(saveLoadDataPiece);
        }
    }
}