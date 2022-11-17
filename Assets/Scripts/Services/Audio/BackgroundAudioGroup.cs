using DG.Tweening;
using UnityEngine;

namespace Services.Audio
{
    public class BackgroundAudioGroup : AudioGroup
    {
        private const float FadeOutTime = 1f;

        private AudioSourceWrapper _wrapper;
        private Tween _tween;
        private float _volume;

        public BackgroundAudioGroup(AudioPool audioPool) : base(audioPool)
        {
        }

        public void PlayLoop(AudioClip clip)
        {
            bool isCreated = _wrapper != null;
            if (!isCreated)
            {
                _wrapper = CreateWrapper();
                _wrapper.SetGroup(this);
                _wrapper.Loop = true;
                _wrapper.SetClip(clip);
                _wrapper.Play();
            }
            else
            {
                if (clip == _wrapper.Clip)
                    return;

                _tween?.Kill(true);

                _volume = 1f;
                _tween = DOTween.To(() => _volume, value => _volume = value, 0, FadeOutTime)
                    .OnUpdate(() => SetCodeVolume01(_volume))
                    .OnComplete(() =>
                    {
                        SetCodeVolume01(1);
                        _wrapper.SetClip(clip);
                        _wrapper.Play();
                        
                        // TODO: Fire tween to fade in
                    });
            }
        }
    }
}