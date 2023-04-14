using System;
namespace MobileVitalsMonitoringTool.Services
{
    /// <summary>
    /// Starts the messaging center.
    /// </summary>
    public class StartServiceMessage
    {
    }

    /// <summary>
    /// Stops the messaging center
    /// </summary>
    public class StopServiceMessage
    {
    }

    /// <summary>
    /// Represents the Location messages in the messaging center
    /// </summary>
    public class LocationMessage
    {
        /// <summary>
        /// Gets or sets the latitude in <see cref="LocationMessage"/>
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude in <see cref="LocationMessage"/>
        /// </summary>
        public double Longitude { get; set; }
    }

    /// <summary>
    /// Represents any error messages in the messaging center
    /// </summary>
    public class LocationErrorMessage
    {
    }
}

