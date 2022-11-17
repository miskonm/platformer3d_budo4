using UnityEngine;
using Zenject;

namespace Services.Audio
{
    public class AudioSourceWrapperOnScene : AudioSourceWrapper
    {
        [SerializeField] private AudioGroupType _groupType;
        
        private IAudioService _audioService;

        [Inject]
        public void Construct(IAudioService audioService)
        {
            _audioService = audioService;
        }

        private void Start() =>
            SetGroup(_audioService.GetGroup(_groupType));

        private void OnDestroy() =>
            ResetGroup();
    }
}