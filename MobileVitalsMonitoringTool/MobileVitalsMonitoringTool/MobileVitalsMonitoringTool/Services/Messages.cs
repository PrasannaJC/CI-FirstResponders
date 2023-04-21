using System;
using MonitoringSuiteLibrary.Models;

namespace MobileVitalsMonitoringTool.Services
{
    /// <summary>
    /// A class to contain a message when the messaging center is started.
    /// </summary>
    public class StartServiceMessage
    {
    }

    /// <summary>
    /// A class to contain a message when the messaging center is stopped.
    /// </summary>
    public class StopServiceMessage
    {
    }

    /// <summary>
    /// A class to contain the location message.
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
    /// A class to contain the vitals message.
    /// </summary>
    public class VitalsMessage
    {
        /// <summary>
        /// Gets or sets the Vitals object in <see cref="VitalsMessage"/>
        /// </summary>
        public Vitals Vitals { get; set; }
    }

    /// <summary>
    /// A class to contain an error message.
    /// </summary>
    public class ErrorMessage
    {
    }
}

