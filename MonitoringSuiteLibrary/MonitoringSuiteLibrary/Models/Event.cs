using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSuiteLibrary.Models
{

    /// <summary>
    /// The struct that represents vitals.
    /// </summary>
    public struct Event
    {
        #region Constructors

        /// <summary>
        /// Creates an Event object
        /// </summary>
        /// <
        /// <param name="e_id">The Event's unique id.</param>
        /// <param name="location">The location of event.</param>
        /// <param name="stime">The start time of event.</param>
        /// <param name="etime">The end time of event. If null, then event is still active.</param>
        public Event(int e_id, string location, DateTime stime, DateTime etime)
        {
            this.EventId = e_id;
            this.Location = location;
            this.StartTime = stime;
            this.EndTime = etime;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the event's unique id.
        /// </summary>
        public int EventId { get; }

        /// <summary>
        /// Gets or sets the event's location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the event's start time.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the event's end time.
        /// </summary>
        public DateTime EndTime { get; set; }

        #endregion
    }
}
