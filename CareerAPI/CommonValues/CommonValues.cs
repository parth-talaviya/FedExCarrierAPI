using System.Configuration;

namespace CareerAPI.CommonValues
{
    /// <summary>
    /// 
    /// </summary>
    public static class CommonValues
    {
        /// <summary>
        /// The token URL
        /// </summary>
        public static string TokenURL = ConfigurationManager.AppSettings["TokenURL"];

        /// <summary>
        /// The token content type
        /// </summary>
        public static string TokenContentType = ConfigurationManager.AppSettings["TokenContentType"];

        /// <summary>
        /// The grant type
        /// </summary>
        public static string GrantType = ConfigurationManager.AppSettings["GrantType"];

        /// <summary>
        /// The client identifier
        /// </summary>
        public static string ClientId = ConfigurationManager.AppSettings["ClientId"];

        /// <summary>
        /// The client secret
        /// </summary>
        public static string ClientSecret = ConfigurationManager.AppSettings["ClientSecret"];

        /// <summary>
        /// The tracking apiurl
        /// </summary>
        public static string TrackingAPIURL = ConfigurationManager.AppSettings["TrackingAPIURL"];

        /// <summary>
        /// The x locale
        /// </summary>
        public static string XLocale = ConfigurationManager.AppSettings["XLocale"];

        /// <summary>
        /// The tracking API content type
        /// </summary>
        public static string TrackingAPIContentType = ConfigurationManager.AppSettings["TrackingAPIContentType"];

        /// <summary>
        /// The tracking API parameter name
        /// </summary>
        public static string TrackingAPIParameterName = ConfigurationManager.AppSettings["TrackingAPIParameterName"];
    }
}