namespace CareerAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class trackingInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="trackingInfo"/> class.
        /// </summary>
        public trackingInfo()
        {
            trackingNumberInfo = new trackingNumberInfo();
        }
        /// <summary>
        /// Gets or sets the tracking number information.
        /// </summary>
        /// <value>
        /// The tracking number information.
        /// </value>
        public trackingNumberInfo trackingNumberInfo { get; set; }
    }
}