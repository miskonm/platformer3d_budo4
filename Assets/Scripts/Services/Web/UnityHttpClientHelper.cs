using System;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Services.Web
{
    public static class UnityHttpClientHelper
    {
        public static Response ConvertResponse(UnityWebRequest request)
        {
            if (request.result == UnityWebRequest.Result.Success)
            {
                return new Response();
            }

            return new Response(CreateException(request));
        }

        public static DtoResponse<TDto> ConvertResponse<TDto>(UnityWebRequest request)
        {
            if (request.result == UnityWebRequest.Result.Success)
            {
                string json = request.downloadHandler.text;
                if (!string.IsNullOrEmpty(json) && TryDeserializeJson(json, out TDto dto))
                {
                    return new DtoResponse<TDto>(dto);
                }
            }

            return new DtoResponse<TDto>(CreateException(request));
        }

        private static ResponseException CreateException(UnityWebRequest request) =>
            new(request.result.ToString(), request.error);

        private static bool TryDeserializeJson<T>(string json, out T data)
        {
            data = default(T);

            try
            {
                data = JsonConvert.DeserializeObject<T>(json);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(
                    $"[{nameof(UnityHttpClientHelper)}:{nameof(TryDeserializeJson)}]: Fail deserialize to '{typeof(T)}' " +
                    $"from json '{json}' with exception '{e}'");
            }

            return false;
        }
    }
}