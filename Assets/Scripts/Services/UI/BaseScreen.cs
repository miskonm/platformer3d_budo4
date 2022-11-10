using UnityEngine;

namespace Services.UI
{
    public abstract class BaseScreen : MonoBehaviour
    {
        public void Show() =>
            gameObject.SetActive(true);

        public void Hide() =>
            gameObject.SetActive(false);
    }
}