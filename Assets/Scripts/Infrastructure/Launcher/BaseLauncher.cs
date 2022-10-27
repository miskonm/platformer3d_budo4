using UnityEngine;

namespace Infrastructure.Launcher
{
    public abstract class BaseLauncher : MonoBehaviour
    {
        public bool IsReady { get; protected set; }
        
        private void Start()
        {
            Launch();
        }

        protected abstract void Launch();
    }
}