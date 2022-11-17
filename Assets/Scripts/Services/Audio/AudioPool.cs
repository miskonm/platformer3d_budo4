using System.Collections.Generic;
using UnityEngine;

namespace Services.Audio
{
    public class AudioPool
    {
        private readonly Transform _parentTransform;
        private readonly Stack<AudioSourceWrapper> _pool = new();

        public AudioPool(Transform parentTransform)
        {
            _parentTransform = parentTransform;
        }

        public AudioSourceWrapper Pop() =>
            _pool.Count > 0 ? _pool.Pop() : Create();

        public void Push(AudioSourceWrapper value) =>
            _pool.Push(value);

        private AudioSourceWrapper Create()
        {
            var go = new GameObject(nameof(AudioSourceWrapper));
            go.transform.SetParent(_parentTransform);
            return go.AddComponent<AudioSourceWrapper>();
        }
    }
}