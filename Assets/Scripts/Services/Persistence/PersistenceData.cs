using System;
using System.Collections.Generic;

namespace Services.Persistence
{
    [Serializable]
    public class PersistenceData
    {
        public string SceneName;
        public List<PersistenceEnemyData> EnemiesData = new List<PersistenceEnemyData>();
    }
}