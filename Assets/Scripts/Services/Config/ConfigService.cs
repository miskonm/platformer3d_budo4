using System.Collections.Generic;
using System.Linq;
using Game.Enemy;
using Services.Assets;
using UnityEngine;

namespace Services.Config
{
    public class ConfigService : IConfigService
    {
        private const string Tag = nameof(ConfigService);

        private Dictionary<EnemyType, EnemyConfig> _enemyConfigsByType;
        private Dictionary<string, LevelConfig> _levelConfigBySceneName;

        public void Bootstrap()
        {
            _enemyConfigsByType = Resources
                .LoadAll<EnemyConfig>(AssetPath.EnemiesConfigsPath)
                .ToDictionary(x => x.EnemyType, x => x);

            _levelConfigBySceneName = Resources
                .LoadAll<LevelConfig>(AssetPath.LevelConfigsPath)
                .ToDictionary(x => x.SceneName, x => x);
        }

        public EnemyConfig GetEnemyConfig(EnemyType enemyType)
        {
            if (!_enemyConfigsByType.ContainsKey(enemyType))
            {
                Debug.LogError($"[{Tag},{nameof(GetEnemyConfig)}] There is no config for enemy type '{enemyType}'");
                return null;
            }

            return _enemyConfigsByType[enemyType];
        }

        public LevelConfig GetLevelConfig(string sceneName)
        {
            if (!_levelConfigBySceneName.ContainsKey(sceneName))
            {
                Debug.LogError($"[{Tag},{nameof(GetLevelConfig)}] There is no config for level '{sceneName}'");
                return null;
            }

            return _levelConfigBySceneName[sceneName];
        }
    }
}