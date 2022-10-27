using Infrastructure.Launcher;

namespace Services.SceneLoading
{
    public interface ISceneLoadingService
    {
        void Load(string sceneName);
        void SetLauncher(BaseLauncher launcher);
    }
}