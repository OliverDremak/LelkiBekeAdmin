using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LelkiBekeAdmin.Network
{
    public static class HTTPComPost<TReq, TRes> where TReq : class where TRes : class, new()
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
            string resultStr = await response.Content.ReadAsStringAsync();

            TRes result;
            if (response.IsSuccessStatusCode)
            {
                if (!string.IsNullOrEmpty(resultStr) && resultStr != "[]")
                {
                    result = JsonSerializer.Deserialize<TRes>(resultStr);
                }
                else
                {
                    result = new TRes(); 
                }
            }
            else
            {
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {resultStr}");
            }

            return result;
        }
    }
}
