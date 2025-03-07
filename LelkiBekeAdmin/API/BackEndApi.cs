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
        private const string BaseUrl = "https://api.innerpeace.jedlik.cloud/api";

        public static Task<T?> GetMenu<T>() where T : class => HTTPCommunication<T>.Get($"{BaseUrl}/menu");
        public static Task<T?> GetTables<T>() where T : class => HTTPCommunication<T>.Get($"{BaseUrl}/tables");
        //public static Task<T?> CreateNewMenuItem<T>(T data) where T : class => HTTPCommunication<T>.Post($"{BaseUrl}/newMenuItem", data);
        //public static Task<T?> ModifyMenuItemById<T>(T data) where T : class => HTTPCommunication<T>.Post($"{BaseUrl}/modifyMenuItem", data);
        //public static Task<T?> DeleteMenuItemById<T>(T data) where T : class => HTTPCommunication<T>.Post($"{BaseUrl}/deleteMenuItem", data);
        public static Task<T?> GetDailySales<T>() where T : class => HTTPCommunication<T>.Get($"{BaseUrl}/salesDaily");
        public static Task<T?> GetTopSellingItems<T>() where T : class => HTTPCommunication<T>.Get($"{BaseUrl}/salesTop-items");
        public static Task<T?> GetSalesSummary<T>() where T : class => HTTPCommunication<T>.Get($"{BaseUrl}/salesSummary");
        public static Task<T?> GetOpenHours<T>() where T : class => HTTPCommunication<T>.Get($"{BaseUrl}/opening-hours");
        //public static Task<T?> SetOpenHours<T>(T data) where T : class => HTTPCommunication<T>.Post($"{BaseUrl}/update-opening-hours", data);
        public static Task<T?> GetContactMessages<T>() where T : class => HTTPCommunication<T>.Get($"{BaseUrl}/contact-messages");
        //public static Task<T?> RegisterUser<T>(T data) where T : class => HTTPCommunication<T>.Post($"{BaseUrl}/register", data);

        public static Task<Tres?> Login<Treq, Tres>(Treq data) where Treq : class where Tres : class, new() => HTTPComPost<Treq, Tres>.Post($"{BaseUrl}/login", data);
        public static Task<Tres?> Register<Treq, Tres>(Treq data) where Treq : class where Tres : class, new() => HTTPComPost<Treq, Tres>.Post($"{BaseUrl}/register", data);
        public static Task<Tres?> CreateNewMenuItem<Treq, Tres>(Treq data) where Treq : class where Tres : class, new() => HTTPComPost<Treq, Tres>.Post($"{BaseUrl}/newMenuItem", data);
        public static Task<Tres?> ModifyMenuItemById<Treq, Tres>(Treq data) where Treq : class where Tres : class, new() => HTTPComPost<Treq, Tres>.Post($"{BaseUrl}/modifyMenuItem", data);
        public static Task<Tres?> DeleteMenuItemById<Treq, Tres>(Treq data) where Treq : class where Tres : class, new() => HTTPComPost<Treq, Tres>.Post($"{BaseUrl}/deleteMenuItem", data);
        public static Task<Tres?> UpdateOpenHours<Treq, Tres>(Treq data) where Treq : class where Tres : class, new() => HTTPComPost<Treq, Tres>.Post($"{BaseUrl}/update-opening-hours", data);
    }
}

