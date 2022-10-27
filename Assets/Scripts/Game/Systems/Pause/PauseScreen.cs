using UnityEngine;
using Zenject;

namespace Game.Systems.Pause
{
    public class PauseScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _innerObject;

        private IPauseService _pauseService;

        [Inject]
        public void Construct(IPauseService pauseService)
        {
            _pauseService = pauseService;
        }

        private void Awake()
        {
            _innerObject.SetActive(false);
        }

        private void Start()
        {
            _pauseService.OnChanged += PausedChanged;
        }

        private void OnDestroy()
        {
            _pauseService.OnChanged -= PausedChanged;
        }

        private void PausedChanged(bool isPaused) =>
            _innerObject.SetActive(isPaused);
    }
}