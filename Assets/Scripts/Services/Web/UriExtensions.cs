using System;
using System.Linq;

namespace Services.Web
{
    public static class UriExtensions
    {
        public static Uri SetQuery(this Uri uri, params (string key, string value)[] parameters)
        {
            UriBuilder uriBuilder = new UriBuilder(uri)
            {
                Query = string.Join($"&", parameters.Select(x => x.key + "=" + x.value).ToArray())
            };

            return uriBuilder.Uri;
        }
    }
}