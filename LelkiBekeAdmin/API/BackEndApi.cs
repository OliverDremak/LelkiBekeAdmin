using LelkiBekeAdmin.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LelkiBekeAdmin.API
{
    public static class BackEndApi
    {
        private const string BaseUrl = "https://bgs.jedlik.eu/innerpeace/backend/api";

        public static Task<T?> GetMenu<T>() where T : class => HTTPCommunication<T>.Get($"{BaseUrl}/menu");
        public static Task<T?> GetTables<T>() where T : class => HTTPCommunication<T>.Get($"{BaseUrl}/tables");
        public static Task<T?> CreateNewMenuItem<T>(T data) where T : class => HTTPCommunication<T>.Post($"{BaseUrl}/newMenuItem", data);
        public static Task<T?> ModifyMenuItemById<T>(T data) where T : class => HTTPCommunication<T>.Post($"{BaseUrl}/modifyMenuItem", data);
        public static Task<T?> DeleteMenuItemById<T>(T data) where T : class => HTTPCommunication<T>.Post($"{BaseUrl}/deleteMenuItem", data);
        public static Task<T?> GetDailySales<T>() where T : class => HTTPCommunication<T>.Get($"{BaseUrl}/salesDaily");
        public static Task<T?> GetTopSellingItems<T>() where T : class => HTTPCommunication<T>.Get($"{BaseUrl}/salesTop-items");
        public static Task<T?> GetSalesSummary<T>() where T : class => HTTPCommunication<T>.Get($"{BaseUrl}/salesSummary");
        public static Task<T?> GetOpenHours<T>() where T : class => HTTPCommunication<T>.Get($"{BaseUrl}/opening-hours");
    }
}

