using UnityEngine;

namespace Services.Config
{
    [CreateAssetMenu(fileName = Tag, menuName = "Configs/Level")]
    public class LevelConfig : ScriptableObject
    {
        private const string Tag = nameof(LevelConfig);

        [SerializeField] private string _sceneName;
        [SerializeField] private EnemySpawnData[] _enemiesSpawnData;

        public string SceneName => _sceneName;
        public EnemySpawnData[] EnemiesSpawnData => _enemiesSpawnData;

        public void SetSceneName(string value) =>
            _sceneName = value;

        public void SetEnemiesData(EnemySpawnData[] value) =>
            _enemiesSpawnData = value;
    }
}