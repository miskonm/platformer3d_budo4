using Infrastructure.Launcher;
using Services.Audio;
using Services.SceneLoading;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Services.UI
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _testButton;
        [SerializeField] private AudioClip _clip;
        

        private ISceneLoadingService _sceneLoadingService;
        private IAudioService _audioService;

        [Inject]
        public void Construct(ISceneLoadingService sceneLoadingService, IAudioService audioService)
        {
            _sceneLoadingService = sceneLoadingService;
            _audioService = audioService;
        }

        private void Awake()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
            _testButton.onClick.AddListener(Test);
        }

        private void Test()
        {
            _audioService.GetGroup<BackgroundAudioGroup>().PlayLoop(_clip);
            // _audioService.Play<SfxAudioGroup>(_clip);
        }

        private void OnPlayButtonClicked()
        {
            _sceneLoadingService.Load(GameLauncher.SceneName);
        }
    }
}