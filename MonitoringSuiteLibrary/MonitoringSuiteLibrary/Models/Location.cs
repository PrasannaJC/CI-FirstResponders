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
        /// <param name="timestamp">The location's timestamp.</param>
        /// <param name="xcoord">The x coordinates of the location.</param>
        /// <param name="ycoord">The y coordinates of the location.</param>
        /// <param name="zcoord">The z coordinates of the location.</param>
        public Location(DateTime timestamp, decimal xcoord, decimal ycoord, decimal zcoord)
        {
            this.Timestamp = timestamp;
            this.XCoord = xcoord;
            this.YCoord = ycoord;
            this.ZCoord = zcoord;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the location's timestamp.
        /// </summary>
        public DateTime Timestamp { get; }

        /// <summary>
        /// Gets or sets the x coordinate of the location.
        /// </summary>
        public decimal XCoord { get; set; }

        /// <summary>
        /// Gets or sets the y coordinate of the location.
        /// </summary>
        public decimal YCoord { get; set; }

        /// <summary>
        /// Gets or sets the z coordinate of the location.
        /// </summary>
        public decimal ZCoord { get; set; }

        #endregion
    }
}
