using System;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemyHp : MonoBehaviour
    {
        // TODO: Debug only, remove later
        [SerializeField] private int _current;

        public event Action<int> OnChanged;

        public int Current
        {
            get => _current;
            set
            {
                if (_current == value)
                    return;

                _current = value;
                OnChanged?.Invoke(_current);
            }
        }

        public int Max { get; set; }
    }
}