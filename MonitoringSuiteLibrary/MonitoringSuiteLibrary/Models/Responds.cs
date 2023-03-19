using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSuiteLibrary.Models
{

    /// <summary>
    /// The struct that represents vitals.
    /// </summary>
    public struct Responds
    {
        #region Constructors

        /// <summary>
        /// Creates a Responds object
        /// </summary>
        /// <
        /// <param name="eventObject">The corresponding event <see cref="MontioringSuiteLibrary.Models.Event"/>.</param>
        /// <param name="firstResponders">The list of first responders that responded the event <see cref="MontioringSuiteLibrary.Models.FirstResponder"/>.</param>
        public Responds(Event eventObject, List<FirstResponder> firstResponders)
        {
            this.Event = eventObject;
            this.FirstResponders = firstResponders;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Event object.
        /// </summary>
        public Event Event { get; set; }

        /// <summary>
        /// Gets or sets the list of first responders.
        /// </summary>
        public List<FirstResponder> FirstResponders { get; set; }

        #endregion
    }
}
