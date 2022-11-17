using UnityEngine;

namespace Services.Audio
{
    public interface IAudioService
    {
        void Bootstrap();

        void Play<TGroup>(AudioClip clip) where TGroup : AudioGroup;
        TGroup GetGroup<TGroup>() where TGroup : AudioGroup;
        AudioGroup GetGroup(AudioGroupType type);
    }
}