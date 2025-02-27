using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LelkiBekeAdmin.Storage
{
    public static class TokenService
    {
        private const string TokenKey = "auth:token";

        public static async Task SaveTokenAsync(string token)
        {
            await SecureStorage.SetAsync(TokenKey, token);
        }

        public static async Task<string> GetTokenAsync()
        {
            return await SecureStorage.GetAsync(TokenKey);
        }

        public static async Task DeleteTokenAsync()
        {
            await SecureStorage.SetAsync(TokenKey, string.Empty);
        }   
    }
}
