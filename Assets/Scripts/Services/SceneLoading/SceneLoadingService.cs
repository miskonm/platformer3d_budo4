using System.Collections;
using Infrastructure.Launcher;
using Services.Coroutine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services.SceneLoading
{
    public class SceneLoadingService : ISceneLoadingService
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private BaseLauncher _launcher;

        public SceneLoadingService(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName)
        {
            _coroutineRunner.StartCoroutine(LoadAsync(sceneName));
        }

        public void SetLauncher(BaseLauncher launcher) =>
            _launcher = launcher;

        private IEnumerator LoadAsync(string sceneName)
        {
            Debug.LogWarning($"SceneLoadingService start loading '{sceneName}'");
            // TODO: Show loading screen
            AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);

            while (!loadSceneAsync.isDone)
                yield return null;

            while (!_launcher.IsReady)
                yield return null;

            // TODO: Hide loading screen when launcher is ready
            Debug.LogWarning($"SceneLoadingService end loading '{sceneName}'");
        }
    }
}