using Services.Save;
using UnityEngine;

namespace P3D.Game
{
    public class SaveZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.LogError($"Perform saving...");
            SaveLoadService.Instance.Save();
        }
    }
}