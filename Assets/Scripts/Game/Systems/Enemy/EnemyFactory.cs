using Game.Enemy;
using Services.Config;
using Services.Save;
using UnityEngine;

namespace Game.Systems.Enemy
{
    public class EnemyFactory : MonoBehaviour
    {
        public void Create(string id, EnemyType enemyType, Vector3 position)
        {
            EnemyConfig enemyConfig = ConfigService.Instance.GetEnemyConfig(enemyType);
            GameObject enemy = Instantiate(enemyConfig.Prefab, position, Quaternion.identity);
            EnemyHp enemyHp = enemy.GetComponent<EnemyHp>();
            enemyHp.SetId(id);
            Register(enemy);
        }

        private void Register(GameObject go)
        {
            ISaveLoadDataPiece[] saveLoadDataPieces = go.GetComponentsInChildren<ISaveLoadDataPiece>();

            foreach (ISaveLoadDataPiece saveLoadDataPiece in saveLoadDataPieces)
                SaveLoadService.Instance.AddSaveLoadPiece(saveLoadDataPiece);
        }
    }
}