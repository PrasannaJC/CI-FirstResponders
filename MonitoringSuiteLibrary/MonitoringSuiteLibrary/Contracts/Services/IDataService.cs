using MonitoringSuiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSuiteLibrary.Contracts.Services
{
    /// <summary>
    /// Interface for data first responder data services. 
    /// </summary>
    public interface IDataService
    {
        #region Public Methods

        /// <summary>
        /// Gets a <see cref="IEnumerable{FirstResponder}"/> representing the first responders.
        /// </summary>
        /// <returns>An IEnumerable of all first responders.</returns>
        public IEnumerable<FirstResponder> GetFirstResponders();

        /// <summary>
        /// Gets a <see cref="IEnumerable{FirstResponder}"/> respresenting the first responders for an event.
        /// </summary>
        /// <param name="eventId">The id corresponding to the specific <see cref="Event"/>.</param>
        /// <returns>An IEnumerable of first responders corresponding to a specific event.</returns>
        public IEnumerable<FirstResponder> GetFirstResponders(int eventId);

        /// <summary>
        /// Gets a <see cref="FirstResponder"/>s vitals.
        /// </summary>
        /// <param name="firstResponderId">The id of the target first responder.</param>
        /// <returns>The current <see cref="Vitals"/> corresponding to the first responder.</returns>
        public Vitals GetFirstResponderVitals(int firstResponderId);

        /// <summary>
        /// Gets a <see cref="FirstResponder"/>s location.
        /// </summary>
        /// <param name="firstResponderId">The id of the target first responder.</param>
        /// <returns>The current <see cref="Location"/> corresponding to the first responder.</returns>
        public Location GetFirstResponderLocation(int firstResponderId);

        /// <summary>
        /// Sets a first responder as inactive.
        /// </summary>
        /// <param name="firstResponderId">The id of the first responder to set inactive.</param>
        /// <returns>Whether or not setting the first responder as inactive was successful.</returns>
        public bool SetFirstResponderInactive(int firstResponderId);

        /// <summary>
        /// Sets a first responder as active and initializes location and vitals data.
        /// </summary>
        /// <param name="firstResponderId">The id of the target first responder.</param>
        /// <param name="vitals">The initial vitals data to store for the first responder.</param>
        /// <param name="location">The initial location data to store for the first responder.</param>
        /// <returns>Whether or not setting the first responder as active was successful.</returns>
        public bool SetFirstResponderActive(int firstResponderId, Vitals vitals, Location location);

        /// <summary>
        /// Updates first responder location.
        /// </summary>
        /// <param name="firstResponderId">The id of the first responder to update.</param>
        /// <param name="location">The <see cref="Location"/> data the current <see cref="Location"/> is updated to.</param>
        /// <returns>Whether or not the update was successful.</returns>
        public bool UpdateFirstResponderLocation(int firstResponderId, Location location);

        /// <summary>
        /// Updates first responder vitals.
        /// </summary>
        /// <param name="firstResponderId">The id of the first responder to update.</param>
        /// <param name="vitals">The <see cref="Vitals"/> data the current <see cref="Vitals"/> is updated to.</param>
        /// <returns>Whether or not the update was successful.</returns>
        public bool UpdateFirstResponderVitals(int firstResponderId, Vitals vitals);

        #endregion
    }
}
