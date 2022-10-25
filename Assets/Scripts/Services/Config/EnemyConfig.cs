using Game.Enemy;
using NaughtyAttributes;
using UnityEngine;

namespace Services.Config
{
    [CreateAssetMenu(fileName = Tag, menuName = "Configs/Enemy")]
    public class EnemyConfig : ScriptableObject
    {
        private const string Tag = nameof(EnemyConfig);

        [SerializeField] private EnemyType _enemyType;
        [ShowAssetPreview()]
        [SerializeField] private GameObject _prefab;

        public EnemyType EnemyType => _enemyType;
        public GameObject Prefab => _prefab;
    }
}