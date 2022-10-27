using System;
using UnityEngine;

namespace Game.Systems.Pause
{
    public class PauseService : MonoBehaviour, IPauseService
    {
        public event Action<bool> OnChanged;

        public bool IsPaused { get; private set; }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }

        private void TogglePause()
        {
            IsPaused = !IsPaused;
            Time.timeScale = IsPaused ? 0 : 1;
            OnChanged?.Invoke(IsPaused);
        }
    }
}