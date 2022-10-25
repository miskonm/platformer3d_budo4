using UnityEngine;

namespace Game.Enemy
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        [SerializeField] private EnemyType _enemyType;

        public EnemyType EnemyType => _enemyType;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.3f);
        }
    }
}