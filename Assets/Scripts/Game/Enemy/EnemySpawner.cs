using System.Linq;
using Game.Systems.Enemy;
using Services.Persistence;
using Services.Save;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemySpawner : MonoBehaviour, ISaveLoadDataPiece
    {
        private EnemyHp _enemyHp;
        private EnemyFactory _enemyFactory;

        public string Id { get; private set; }
        public EnemyType EnemyType { get; private set; }

        public void Construct(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        public void SetId(string value) =>
            Id = value;

        public void SetEnemyType(EnemyType enemyType) =>
            EnemyType = enemyType;

        public void Load(PersistenceData data)
        {
            var persistenceEnemyData = GetEnemyData(data);
            if (persistenceEnemyData == null)
            {
                Spawn();
                return;
            }

            if (persistenceEnemyData.Hp != 0)
                Spawn(persistenceEnemyData.Hp);
        }

        public void Save(PersistenceData data)
        {
            if (_enemyHp == null)
                return;

            var persistenceEnemyData = GetEnemyData(data);
            if (persistenceEnemyData == null)
            {
                persistenceEnemyData = new PersistenceEnemyData()
                {
                    Id = Id,
                };
                data.EnemiesData.Add(persistenceEnemyData);
            }

            persistenceEnemyData.Hp = _enemyHp.Current;
        }

        private void Spawn(int hp = -1)
        {
            GameObject enemyObj = _enemyFactory.CreateEnemy(EnemyType, transform.position);
            _enemyHp = enemyObj.GetComponent<EnemyHp>();

            if (hp != -1)
            {
                _enemyHp.Current = hp;
            }
        }

        private PersistenceEnemyData GetEnemyData(PersistenceData data) =>
            data.EnemiesData.FirstOrDefault(x => x.Id == Id);
    }
}