using System.Collections;

namespace Services.Coroutine
{
    public interface ICoroutineRunner
    {
        UnityEngine.Coroutine StartCoroutine(IEnumerator enumerator);
    }
}