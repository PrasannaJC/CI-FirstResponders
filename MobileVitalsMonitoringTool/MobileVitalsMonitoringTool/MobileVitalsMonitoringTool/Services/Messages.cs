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
        /// Gets or sets the Location object in <see cref="LocationMessage"/>
        /// </summary>
        public Location Location { get; set; }
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
    /// A class to contain the first responder message.
    /// </summary>
    public class FirstResponderMessage
    {
        /// <summary>
        /// Gets or sets the FirstResponder object in <see cref="FirstResponderMessage"/>
        /// </summary>
        public FirstResponder FirstResponder { get; set; }
    }

    /// <summary>
    /// A class to contain an error message.
    /// </summary>
    public class ErrorMessage
    {
    }
}

