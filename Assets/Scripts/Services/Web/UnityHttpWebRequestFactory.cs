using System;
using System.Collections;
using Services.Coroutine;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

namespace Services.Web
{
    public class UnityHttpWebRequestFactory : MonoBehaviour, IHttpWebRequestFactory
    {
        private const int WebRequestTimeout = 5;

        private ICoroutineRunner _coroutineRunner;

        [Inject]
        public void Construct(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Get(Uri uri, Action<Response> responseCallback) =>
            _coroutineRunner.StartCoroutine(GetRequest(uri, req => HandleHttpResponse(req, responseCallback)));

        public void Get<TDto>(Uri uri, Action<DtoResponse<TDto>> responseCallback) =>
            _coroutineRunner.StartCoroutine(GetRequest(uri, req => HandleHttpResponse(req, responseCallback)));

        private IEnumerator GetRequest(Uri uri, Action<UnityWebRequest> requestCompletedCallback)
        {
            using UnityWebRequest webRequest = UnityWebRequest.Get(uri);
            webRequest.timeout = WebRequestTimeout;
            // Setup if needed
            yield return webRequest.SendWebRequest();
            requestCompletedCallback?.Invoke(webRequest);
        }

        private void HandleHttpResponse(UnityWebRequest request, Action<Response> responseCallback)
        {
            Response response = UnityHttpClientHelper.ConvertResponse(request);
            responseCallback?.Invoke(response);
        }

        private void HandleHttpResponse<TDto>(UnityWebRequest request, Action<DtoResponse<TDto>> responseCallback)
        {
            DtoResponse<TDto> response = UnityHttpClientHelper.ConvertResponse<TDto>(request);
            responseCallback?.Invoke(response);
        }
    }
}