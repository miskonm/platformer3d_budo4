using System;

namespace Services.Web
{
    public interface IHttpWebRequestFactory
    {
        void Get(Uri uri, Action<Response> responseCallback);
        void Get<TDto>(Uri uri, Action<DtoResponse<TDto>> callback);
        
        // TODO: Add put, post, delete etc. methods
    }
}