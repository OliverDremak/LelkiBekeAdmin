using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LelkiBekeAdmin.Network
{
    public class HTTPCommunication<T> where T : class
    {
        public static async Task<T?> Get(string url)
        {
            try
            {
                using var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                using var response = await client.SendAsync(request).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    string resultStr = await response.Content.ReadAsStringAsync();
                    T? result = JsonSerializer.Deserialize<T>(resultStr);
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }

        }
        public static async Task<T?> Post(string url, T data)
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
                T? result = JsonSerializer.Deserialize<T>(resultStr);
                return result;
            }
            return null;
        }
    }
}
