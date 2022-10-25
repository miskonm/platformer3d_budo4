using System.Linq;
using Services.Persistence;
using Services.Save;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemyHp : MonoBehaviour, ISaveLoadDataPiece
    {
        [SerializeField] private int _max;

        // TODO: Debug only, remove later
        [SerializeField] private int _current;

      

        private void Awake()
        {
            Max = _max;
            Current = Max;
        }

        public void Load(PersistenceData data)
        {
            PersistenceEnemyData persistenceEnemyData = data.EnemiesData.FirstOrDefault(x => x.Id == Id);
            if (persistenceEnemyData == null)
            {
                Debug.LogWarning($"{name} no data loaded");
                return;
            }
            
            Current = persistenceEnemyData.Hp;
        }

        public void Save(PersistenceData data)
        {
            PersistenceEnemyData persistenceEnemyData = data.EnemiesData.FirstOrDefault(x => x.Id == Id);
            if (persistenceEnemyData == null)
            {
                persistenceEnemyData = new PersistenceEnemyData()
                {
                    Id = Id,
                };
                data.EnemiesData.Add(persistenceEnemyData);
            }
            
            persistenceEnemyData.Hp = Current;
        }

        public void SetId(string id) =>
            Id = id;
    }
}