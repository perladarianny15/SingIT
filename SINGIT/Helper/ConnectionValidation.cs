using System;
using Xamarin.Essentials;

namespace SINGIT.Helper
{
    public static class ConnectionValidation
    {
        public static bool HaveInternetConnection()
        {
            bool Result = false;

            var Current = Connectivity.NetworkAccess;
            if (Current == NetworkAccess.Internet)
            {
                Result = true;
            }

           return Result;
        }
    }
}
