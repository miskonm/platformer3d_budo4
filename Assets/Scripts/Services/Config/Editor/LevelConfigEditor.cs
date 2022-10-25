using System.Linq;
using Game.Enemy;
using P3D.Game;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services.Config
{
    [CustomEditor(typeof(LevelConfig))]
    public class LevelConfigEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Collect Data"))
            {
                LevelConfig config = (LevelConfig) target;

                config.SetSceneName(SceneManager.GetActiveScene().name);

                EnemySpawnData[] spawnDataArray = FindObjectsOfType<EnemySpawnPoint>()
                    .Select(x => new EnemySpawnData(x.GetComponent<UniqueId>().Id, x.transform.position, x.EnemyType))
                    .ToArray();

                config.SetEnemiesData(spawnDataArray);
                
                EditorUtility.SetDirty(config);
            }
        }
    }
}