using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LelkiBekeAdmin.Network
{
    public static class HTTPComPost<TReq, TRes> where TReq : class where TRes : class
    {
        public static async Task<TRes?> Post(string url, TReq data)
        {
            using var client = new HttpClient();
            var SD = JsonSerializer.Serialize(data);
            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = JsonContent.Create(data)

            };
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            using var response = await client.SendAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string resultStr = await response.Content.ReadAsStringAsync();
                TRes? result = JsonSerializer.Deserialize<TRes>(resultStr);
                return result;
            }
            return null;
        }
    }
}
