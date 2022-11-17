using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Services.Audio
{
    public class AudioSourceWrapper : MonoBehaviour
    {
        private AudioGroup _audioGroup;
        private AudioSource _audioSource;

        private float _volume01 = 1;

        private AudioSource AudioSource
        {
            get
            {
                if (_audioSource != null)
                    return _audioSource;

                _audioSource = GetComponent<AudioSource>();

                if (_audioSource == null)
                    _audioSource = gameObject.AddComponent<AudioSource>();

                _audioSource.volume = 0f;
                return _audioSource;
            }
        }

        public bool IsPlaying => AudioSource.isPlaying;

        public bool Loop
        {
            get => AudioSource.loop;
            set => AudioSource.loop = value;
        }

        public AudioClip Clip => AudioSource.clip;

        public void Play()
        {
            AudioSource.Play();
        }

        public void SetVolume01(float value)
        {
            _volume01 = value;
            UpdateVolume();
        }

        public async UniTask PlayAsync(CancellationToken cancellationToken)
        {
            Play();

            // bool isCanceled = await UniTask.WaitUntil(() => AudioSource.isPlaying, cancellationToken: cancellationToken)
            //     .SuppressCancellationThrow();
            //
            // if (isCanceled)
            //     AudioSource.Stop();

            while (AudioSource.isPlaying)
            {
                await UniTask.Yield();
            
                if (cancellationToken.IsCancellationRequested)
                {
                    AudioSource.Stop();
            
                    break;
                }
            }
        }

        public void SetClip(AudioClip audioClip)
        {
            AudioSource.clip = audioClip;
        }

        public void ResetWrapper()
        {
            AudioSource.clip = null;
            AudioSource.volume = 0f;
            Loop = false;
        }

        public void SetGroup(AudioGroup audioGroup)
        {
            _audioGroup = audioGroup;
            _audioGroup.OnVolumeChanged += UpdateVolume;
            UpdateVolume();
        }

        public void ResetGroup()
        {
            _audioGroup.OnVolumeChanged -= UpdateVolume;
            _audioGroup = null;
        }

        private void UpdateVolume() =>
            AudioSource.volume = _volume01 * _audioGroup.NormalizedVolume01;
    }
}