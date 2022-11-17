using System;
using System.Collections.Generic;
using UnityEngine;

namespace Services.Audio
{
    public class AudioService : IAudioService
    {
        private readonly AudioGroupMapper _mapper;
        private readonly Dictionary<Type, AudioGroup> _groupsByType;

        public AudioService(List<AudioGroup> groups, AudioGroupMapper mapper)
        {
            _mapper = mapper;
            _groupsByType = new Dictionary<Type, AudioGroup>();
            foreach (AudioGroup group in groups)
                _groupsByType.Add(group.GetType(), group);
        }

        public void Bootstrap()
        {
            foreach (AudioGroup group in _groupsByType.Values)
                group.Bootstrap();
        }

        public void Play<TGroup>(AudioClip clip) where TGroup : AudioGroup =>
            GetGroup<TGroup>().Play(clip);

        public TGroup GetGroup<TGroup>() where TGroup : AudioGroup =>
            _groupsByType[typeof(TGroup)] as TGroup;

        public AudioGroup GetGroup(AudioGroupType type) =>
            _groupsByType[_mapper.GetAudioGroupType(type)];
    }
}