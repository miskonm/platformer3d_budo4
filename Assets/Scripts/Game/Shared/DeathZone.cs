using UnityEngine;

namespace P3D.Game
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            // TODO: Refactor in future
            Reloader.Reload();
        }
    }
}