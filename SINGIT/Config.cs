using System;
using System.Text.RegularExpressions;

namespace SINGIT
{
    public class Config
    {
        public Config()
        {
        }

        public static string ApiKey = "aa2ae8cce618bff1f84b172ea0c75787";
        public static string ApiUrl = "http://api.musixmatch.com";
        public static string ApiHostName
        {
            get
            {
                var apiHostName = Regex.Replace(ApiUrl, @"^(?:http(?:s)?://)?(?:www(?:[0-9]+)?\.)?", string.Empty, RegexOptions.IgnoreCase)
                                   .Replace("/", string.Empty);
                return apiHostName;
            }
        }
    }
}
