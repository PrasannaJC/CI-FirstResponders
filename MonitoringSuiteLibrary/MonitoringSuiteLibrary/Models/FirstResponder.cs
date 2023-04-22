using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSuiteLibrary.Models
{
    /// <summary>
    /// The implementation of a first responder.
    /// </summary>
    public class FirstResponder
    {
        #region Constructors

        /// <summary>
        /// Creates a First Responder object
        /// </summary>
        /// <param name="w_id">The first responders unique id.</param>
        /// <param name="fName">The first responders first name.</param>
        /// <param name="lName">The first responders last name.</param>
        /// <param name="age">The first responders age.</param>
        /// <param name="sex">The first responders sex.</param>
        /// <param name="height">The first responders height.</param>
        /// <param name="weight">The first responders weight.</param>
        /// <param name="active">The first responders active status.</param>
        /// <param name="alert">The first responders alert status.</param>
        /// <param name="vitals">The first responders <see cref="MonitoringSuiteLibrary.Models.Vitals"/>.</param>
        /// <param name="location">The first responders <see cref="MonitoringSuiteLibrary.Models.Location"/>.</param>
        public FirstResponder(int w_id, string fName, string lName, int age, char sex, double height, int weight, bool active, bool alert, Vitals? vitals, Location? location)
        {
            this.FirstResponderId = w_id;
            this.FName = fName;
            this.LName = lName;
            this.Age = age;
            this.Sex = sex;
            this.Height = height;
            this.Weight = weight;
            this.Active = active;
            this.Alert = alert;
            this.Vitals = vitals;
            this.Location = location;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the id of the first responder in the database.
        /// The id is created automatically when a new entry is added to the workers table in the DB
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
        /// Gets the first responders age.
        /// </summary>
        public int Age { get; }

        /// <summary>
        /// Gets the first responders sex.
        /// </summary>
        public char Sex { get; }

        /// <summary>
        /// Gets the first responders height.
        /// </summary>
        public double Height { get; }

        /// <summary>
        /// Gets the first responders wight.
        /// </summary>
        public int Weight { get; }

        /// <summary>
        /// Gets the first responders active status.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets the first responders active status.
        /// </summary>
        public bool Alert { get; set; }

        /// <summary>
        /// Gets or sets the first responders <see cref="MonitoringSuiteLibrary.Models.Vitals"/>.
        /// </summary>
        public Vitals? Vitals { get; set; }  

        /// <summary>
        /// Gets or sets the first responders <see cref="MonitoringSuiteLibrary.Models.Location"/>.
        /// </summary>
        public Location? Location { get; set; }

        /// <summary>
        /// Gets or sets whether or not the first responders vitals and location data is current.
        /// </summary>
        public bool IsVitalsAndLocationCurrent
        {
            get
            {
                if (Vitals == null || Location == null)
                {
                    return false;
                }

                TimeSpan decayTime = TimeSpan.FromMinutes(1);

                if (!(Vitals.Value.Timestamp > DateTime.UtcNow - decayTime))
                {
                    return false;
                }

                if (!(Location.Value.Timestamp > DateTime.UtcNow - decayTime))
                {
                    return false;
                }

                return true;
            }
        }

        #endregion
    }
}
