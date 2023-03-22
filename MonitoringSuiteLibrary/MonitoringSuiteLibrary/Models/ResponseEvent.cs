using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSuiteLibrary.Models
{

    /// <summary>
    /// The struct that represents vitals.
    /// </summary>
    public struct ResponseEvent
    {
        #region Constructors

        /// <summary>
        /// Creates a ResponseEvent object
        /// </summary>
        /// <
        /// <param name="e_id">The Event's unique id.</param>
        /// <param name="location">The location of event.</param>
        /// <param name="stime">The start time of event.</param>
        /// <param name="etime">The end time of event. If null, then event is still active.</param>
        /// <param name="notes">The event notes.</param>
        /// <param name="firstResponders">The list of first responders that responded the event <see cref="MonitoringSuiteLibrary.Models.FirstResponder"/>.</param>
        public ResponseEvent(int e_id, string location, DateTime stime, DateTime etime, string notes, IEnumerable<FirstResponder> firstResponders)
        {
            this.EventId = e_id;
            this.Location = location;
            this.StartTime = stime;
            this.EndTime = etime;
            this.Notes = notes;
            this.FirstResponders = firstResponders;
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

        /// <summary>
        /// Gets or sets the Event notes.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the list of first responders.
        /// </summary>
        public IEnumerable<FirstResponder> FirstResponders { get; set; }

        #endregion
    }
}
