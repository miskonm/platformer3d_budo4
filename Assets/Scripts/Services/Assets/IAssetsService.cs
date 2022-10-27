using UnityEngine;

namespace Services.Assets
{
    public interface IAssetsService
    {
        T Load<T>(string path) where T : Object;
    }
}