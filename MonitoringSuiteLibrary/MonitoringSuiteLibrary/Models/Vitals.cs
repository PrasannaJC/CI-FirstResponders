using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSuiteLibrary.Models
{
    /// <summary>
    /// The struct that represents vitals.
    /// </summary>
    public struct Vitals
    {
        #region Constructors

        /// <summary>
        /// Creates a Vitals object
        /// </summary>
        /// <
        /// <param name="timestamp">The vitals' timestamp.</param>
        /// <param name="bloodoxy">The blood oxygen level.</param>
        /// <param name="heartrate">The heart rate level.</param>
        /// <param name="sysbp">The Systolic blood pressure level.</param>
        /// <param name="diabp">The diastolic blood pressure level.</param>
        /// <param name="resprate">The respiratory rate.</param>
        /// <param name="tempf">The body temperature in fahrenheit.</param>
        public Vitals(DateTime timestamp, int bloodoxy, int heartrate, int sysbp, int diabp, int resprate, int tempf)
        {
            this.Timestamp = timestamp;
            this.Bloodoxy = bloodoxy;
            this.Heartrate = heartrate;
            this.Sysbp = sysbp;
            this.Diabp = diabp;
            this.Resprate = resprate;
            this.Tempf = tempf;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the vitals' timestamp.
        /// </summary>
        public DateTime Timestamp { get; }

        /// <summary>
        /// Gets or sets the bloody oxygen level.
        /// </summary>
        public int Bloodoxy { get; set; }

        /// <summary>
        /// Gets or sets the heart rate.
        /// </summary>
        public int Heartrate { get; set; }

        /// <summary>
        /// Gets or sets the systolic blood pressure level.
        /// </summary>
        public int Sysbp { get; set; }

        /// <summary>
        /// Gets or sets the diastolic blood pressure level.
        /// </summary>
        public int Diabp { get; set; }

        /// <summary>
        /// Gets or sets the respiratory rate.
        /// </summary>
        public int Resprate { get; set; }

        /// <summary>
        /// Gets or sets the body temperature in fahrenheit.
        /// </summary>
        public int Tempf { get; set; }

        #endregion
    }
}
