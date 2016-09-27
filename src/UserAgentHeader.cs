using System;
using System.Collections.Generic;
using System.Text;

namespace PayPal.Api
{
    /// <summary>
    /// PayPal User-Agent Header implementation class
    /// </summary>
    internal class UserAgentHeader
    {
        /// <summary>
        /// Returns a PayPal specific User-Agent HTTP Header
        /// </summary>
        /// <returns>Dictionary containing User-Agent HTTP Header</returns>
        public static Dictionary<string, string> GetHeader()
        {
            var userAgentDictionary = new Dictionary<string, string>
            {
                {BaseConstants.UserAgentHeader, UserAgentHeader.GetUserAgentHeader()}
            };
            return userAgentDictionary;
        }

        /// <summary>
        /// Creates the signature for the UserAgent header.
        /// </summary>
        /// <returns>A string containing the signature for the UserAgent header.</returns>
        private static string GetUserAgentHeader()
        {
            return
                "PayPalSDK/PayPal-NET-SDK 1.7.4 (lang=DOTNET;v=4.5.1;clr=4.0.30319.42000;bit=64;os=Microsoft Windows NT 6.2.9200.0)";
        }
    }
}
