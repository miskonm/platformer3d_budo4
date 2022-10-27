using UnityEngine;

namespace Game.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        private EnemyHp _enemyHp;

        public bool IsDead { get; private set; }

        private void Awake()
        {
            _enemyHp = GetComponent<EnemyHp>();
            _enemyHp.OnChanged += OnHpChanged;
        }

        private void OnHpChanged(int current)
        {
            if (current > 0)
                return;

            Die();
        }

        private void Die()
        {
            // TODO: Some logic
            IsDead = true;

            Destroy(gameObject, 1.5f);
        }
    }
}