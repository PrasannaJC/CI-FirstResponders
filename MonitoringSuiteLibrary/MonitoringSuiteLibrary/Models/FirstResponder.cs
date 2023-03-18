using System;
using System.Collections.Generic;
using System.Text;

namespace MontioringSuiteLibrary.Models
{
    /// <summary>
    /// The implementation of a first responder.
    /// </summary>
    public class FirstResponder
    {
        #region Constructors

        /// <summary>
        /// Creates a First 
        /// </summary>
        /// <
        /// <param name="fName">The first responders first name.</param>
        /// <param name="lName">The first responders last name.</param>
        /// <param name="vitals">The first responders <see cref="MontioringSuiteLibrary.Models.Vitals"/>.</param>
        /// <param name="location">The first responders <see cref="MontioringSuiteLibrary.Models.Location"/>.</param>
        public FirstResponder(string fName, string lName, Vitals vitals, Location location)
        {
            this.FName = fName;
            this.LName = lName;
            this.Vitals = vitals;
            this.Location = location;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the id of the first responder in the database.
        /// TODO: Decide how the <see cref="FirstResponderId"/> should be populated for new First Responders, and for when the class is used to pull the first responders from the DB. Perhaps two contructors.
        /// </summary>
        public int FirstResponderId { get; }

        /// <summary>
        /// Gets the first responders first name.
        /// </summary>
        public string FName { get; }

        /// <summary>
        /// Gets the first responders last name.
        /// </summary>
        public string LName { get; }

        /// <summary>
        /// Gets or sets the first responders <see cref="MontioringSuiteLibrary.Models.Vitals"/>.
        /// </summary>
        public Vitals Vitals { get; set; }  

        /// <summary>
        /// Gets or sets the first responders <see cref="MontioringSuiteLibrary.Models.Location"/>.
        /// </summary>
        public Location Location { get; set; }

        #endregion
    }
}
