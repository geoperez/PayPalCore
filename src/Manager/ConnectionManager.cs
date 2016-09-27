using System;
using System.Collections.Generic;
using System.Net;

using PayPal.Util;

namespace PayPal.Api
{
    /// <summary>
    ///  ConnectionManager retrieves HttpConnection objects used by API service
    /// </summary>
    public sealed class ConnectionManager
    {
        /// <summary>
        /// Logger
        /// </summary>
        //private static Logger logger = Logger.GetLogger(typeof(ConnectionManager));

        /// <summary>
        /// System.Lazy type guarantees thread-safe lazy-construction
        /// static holder for instance, need to use lambda to construct since constructor private
        /// </summary>
        private static readonly Lazy<ConnectionManager> lazyConnectionManager = new Lazy<ConnectionManager>(() => new ConnectionManager());

        /// <summary>
        /// Accessor for the Singleton instance of ConnectionManager
        /// </summary>
        public static ConnectionManager Instance { get { return lazyConnectionManager.Value; } }

        private bool logTlsWarning = false;
        
        /// <summary>
        /// Create and Config a HttpWebRequest
        /// </summary>
        /// <param name="config">Config properties</param>
        /// <param name="url">Url to connect to</param>
        /// <returns></returns>
        public HttpWebRequest GetConnection(Dictionary<string, string> config, string url)
        {
            HttpWebRequest httpRequest = null;
            try
            {
                httpRequest = (HttpWebRequest)WebRequest.Create(url);
            }
            catch (UriFormatException ex)
            {
                throw new ConfigException("Invalid URI: " + url);
            }
            
            // TODO: Complete
            // Set connection timeout
            //int ConnectionTimeout = 0;
            //if(!config.ContainsKey(BaseConstants.HttpConnectionTimeoutConfig) ||
            //    !int.TryParse(config[BaseConstants.HttpConnectionTimeoutConfig], out ConnectionTimeout)) {
            //    int.TryParse(ConfigManager.GetDefault(BaseConstants.HttpConnectionTimeoutConfig), out ConnectionTimeout);
            //}
            //httpRequest.Timeout = ConnectionTimeout;
            
            //// Don't set the Expect: 100-continue header as it's not supported
            //// well by Akamai and can negatively impact performance.
            //httpRequest.ServicePoint.Expect100Continue = false;
            
            return httpRequest;
        }
    }
}
