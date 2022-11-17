using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Services.Audio
{
    public abstract class AudioGroup
    {
        private readonly AudioPool _audioPool;

        protected AudioGroup(AudioPool audioPool)
        {
            _audioPool = audioPool;
        }

        public float SettingsVolume01 { get; private set; }
        public float CodeVolume01 { get; private set; }
        public float NormalizedVolume01 { get; private set; }

        public event Action OnVolumeChanged;

        public void Bootstrap()
        {
            SettingsVolume01 = LoadSettingsVolume();
            CodeVolume01 = 1f;
            UpdateNormalizedVolume();
        }

        public void SetSettingsVolume01(float value)
        {
            SettingsVolume01 = value;
            PlayerPrefs.SetFloat(GetPlayerPrefsKey(), value);
            UpdateNormalizedVolume();
        }

        public void SetCodeVolume01(float value)
        {
            CodeVolume01 = value;
            UpdateNormalizedVolume();
        }

        public void Play(AudioClip clip) =>
            PlayAsync(clip, CancellationToken.None).Forget();

        public async UniTask PlayAsync(AudioClip audioClip, CancellationToken cancellationToken)
        {
            AudioSourceWrapper audioSourceWrapper = CreateWrapper();
            audioSourceWrapper.SetGroup(this);
            audioSourceWrapper.SetClip(audioClip);
            // audioSourceWrapper.SetVolume01(audioClipData.Volume);

            await audioSourceWrapper.PlayAsync(cancellationToken);

            audioSourceWrapper.ResetWrapper();
            audioSourceWrapper.ResetGroup();
            _audioPool.Push(audioSourceWrapper);
        }

        protected  AudioSourceWrapper CreateWrapper() =>
            _audioPool.Pop();

        private string GetPlayerPrefsKey() =>
            GetType().Name;

        private float LoadSettingsVolume() =>
            PlayerPrefs.GetFloat(GetPlayerPrefsKey(), 1f);

        private void UpdateNormalizedVolume()
        {
            NormalizedVolume01 = CodeVolume01 * SettingsVolume01;
            OnVolumeChanged?.Invoke();
        }
    }
}