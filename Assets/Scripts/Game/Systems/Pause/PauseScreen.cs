using UnityEngine;

namespace Game.Systems.Pause
{
    public class PauseScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _innerObject;

        private void Awake()
        {
            _innerObject.SetActive(false);
        }

        private void Start()
        {
            PauseService.Instance.OnChanged += PausedChanged;
        }

        private void OnDestroy()
        {
            PauseService.Instance.OnChanged -= PausedChanged;
        }

        private void PausedChanged(bool isPaused)
        {
            _innerObject.SetActive(isPaused);
        }
    }
}