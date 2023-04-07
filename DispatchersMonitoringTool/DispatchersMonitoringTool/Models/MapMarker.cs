using MonitoringSuiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchersMonitoringTool.Models
{
    /// <summary>
    /// Represents data to be placed on a map.
    /// </summary>
    public class MapMarker
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets a string to display on the map.
        /// </summary>
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the map markers label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the map marker.
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// Gets or sets the latitude of the map marker.
        /// </summary>
        public decimal Latitude { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a <see cref="MapMarker"/>
        /// </summary>
        /// <param name="display">A string to display with the map marker.</param>
        /// <param name="longitude">The map markers longitude.</param>
        /// <param name="latitude">The map markers latitude.</param>
        /// <param name="label">The map markers label.</param>
        public MapMarker(string display, decimal longitude, decimal latitude, string label = null)
        {
            Display = display;
            Longitude = longitude;
            Latitude = latitude;
            Label = label;
        }

        #endregion
    }
}
