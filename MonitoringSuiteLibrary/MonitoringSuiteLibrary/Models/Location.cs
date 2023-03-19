using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSuiteLibrary.Models
{

    /// <summary>
    /// The struct that represents vitals.
    /// </summary>
    public struct Location
    {
        #region Constructors

        /// <summary>
        /// Creates a Location object
        /// </summary>
        /// <
        /// <param name="timestamp">The location's timestamp.</param>
        /// <param name="location">The location coordinates.</param>
        public Location(DateTime timestamp, string location)
        {
            this.Timestamp = timestamp;
            this.Coordinates = location;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the location's timestamp.
        /// </summary>
        public DateTime Timestamp { get; }

        /// <summary>
        /// Gets or sets the location coordinated.
        /// </summary>
        public string Coordinates { get; set; }

        #endregion
    }
}
