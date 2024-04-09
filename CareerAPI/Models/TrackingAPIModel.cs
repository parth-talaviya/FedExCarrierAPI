using System.Collections.Generic;

namespace CareerAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TrackingAPIModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackingAPIModel"/> class.
        /// </summary>
        public TrackingAPIModel()
        {
            trackingInfo = new List<trackingInfo>();
        }
        /// <summary>
        /// Gets or sets the tracking information.
        /// </summary>
        /// <value>
        /// The tracking information.
        /// </value>
        public List<trackingInfo> trackingInfo { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [include detailed scans].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [include detailed scans]; otherwise, <c>false</c>.
        /// </value>
        public bool includeDetailedScans { get; set; }
    }
}