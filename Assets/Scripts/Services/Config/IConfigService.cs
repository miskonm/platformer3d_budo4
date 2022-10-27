using Game.Enemy;

namespace Services.Config
{
    public interface IConfigService
    {
        void Bootstrap();
        EnemyConfig GetEnemyConfig(EnemyType enemyType);
        LevelConfig GetLevelConfig(string sceneName);
    }
}