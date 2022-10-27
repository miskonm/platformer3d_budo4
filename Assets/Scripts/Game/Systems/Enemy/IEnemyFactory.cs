using Game.Enemy;
using UnityEngine;

namespace Game.Systems.Enemy
{
    public interface IEnemyFactory
    {
        GameObject CreateEnemy(EnemyType enemyType, Vector3 position);
        GameObject CreateSpawner(string id, EnemyType enemyType, Vector3 position);
    }
}