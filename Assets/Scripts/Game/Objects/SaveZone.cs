using Services.Save;
using UnityEngine;
using Zenject;

namespace P3D.Game
{
    public class SaveZone : MonoBehaviour
    {
        private ISaveLoadService _saveLoadService;

        [Inject]
        public void Construct(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.LogWarning($"Perform saving...");
            _saveLoadService.Save();
        }
    }
}