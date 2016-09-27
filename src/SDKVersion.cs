namespace PayPal.Api
{
    /// <summary>
    /// Class for inspecting the ID and version of this SDK.
    /// </summary>
    public class SDKVersion
    {
        /// <summary>
        /// SDK ID used in User-Agent HTTP header
        /// </summary>
        /// <returns>SDK ID</returns>
        public static string GetSDKId() { return BaseConstants.SdkName; }

        /// <summary>
        /// SDK Version used in User-Agent HTTP header
        /// </summary>
        /// <returns>SDK Version</returns>
        public static string GetSDKVersion() { return BaseConstants.SdkVersion; }
    }
}
