using UnityEngine;

namespace Services.Assets
{
    public class AssetsService : IAssetsService
    {
        public T Load<T>(string path) where T : Object =>
            Resources.Load<T>(path);
    }
}