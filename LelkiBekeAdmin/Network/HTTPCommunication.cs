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
    }
}
