using MonitoringSuiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringSuiteLibrary.Contracts.Services
{
    /// <summary>
    /// Interface for data first responder data services. 
    /// </summary>
    public interface IDataService
    {
        #region Public Methods

        /// <summary>
        /// Gets a <see cref="IEnumerable{FirstResponder}"/> representing the active first responders.
        /// </summary>
        /// <returns>An IEnumerable of all active first responders.</returns>
        public Task<IEnumerable<FirstResponder>> GetActiveFirstRespondersAsync();

        /// <summary>
        /// Gets a <see cref="FirstResponder"/>.
        /// </summary>
        /// <param name="firstResponderId">The id of the target first responder.</param>
        /// <returns>A <see cref="FirstResponder"/> corresponding to the firstResponderId</returns>
        public Task<FirstResponder?> GetFirstResponderAsync(int firstResponderId);

        /// <summary>
        /// Gets a <see cref="IEnumerable{FirstResponder}"/> respresenting the first responders for an event.
        /// </summary>
        /// <param name="eventId">The id corresponding to the specific <see cref="Event"/>.</param>
        /// <returns>An IEnumerable of first responders corresponding to a specific event.</returns>
        public Task<IEnumerable<FirstResponder>> GetFirstRespondersAsync(int eventId);

        /// <summary>
        /// Gets a <see cref="FirstResponder"/>s vitals.
        /// </summary>
        /// <param name="firstResponderId">The id of the target first responder.</param>
        /// <returns>The current <see cref="Vitals"/> corresponding to the first responder.</returns>
        public Task<Vitals?> GetFirstResponderVitalsAsync(int firstResponderId);

        /// <summary>
        /// Gets a <see cref="FirstResponder"/>s location.
        /// </summary>
        /// <param name="firstResponderId">The id of the target first responder.</param>
        /// <returns>The current <see cref="Location"/> corresponding to the first responder.</returns>
        public Task<Location?> GetFirstResponderLocationAsync(int firstResponderId);

        /// <summary>
        /// Sets a first responder as inactive.
        /// </summary>
        /// <param name="firstResponderId">The id of the first responder to set inactive.</param>
        /// <returns>Whether or not setting the first responder as inactive was successful.</returns>
        public Task<bool> SetFirstResponderInactiveAsync(int firstResponderId);

        /// <summary>
        /// Sets a first responder as active.
        /// </summary>
        /// <param name="firstResponderId">The id of the target first responder.</param>
        /// <returns>Whether or not setting the first responder as active was successful.</returns>
        public Task<bool> SetFirstResponderActiveAsync(int firstResponderId);

        /// <summary>
        /// Sets a first responder alert status as false.
        /// </summary>
        /// <param name="firstResponderId">The id of the target first responder.</param>
        /// <returns>Whether or not setting the first responder's alert to false was successful.</returns>
        public Task<bool> SetFirstResponderAlertFalseAsync(int firstResponderId);

        /// <summary>
        /// Sets a first responder alert status as true.
        /// </summary>
        /// <param name="firstResponderId">The id of the target first responder.</param>
        /// <returns>Whether or not setting the first responder's alert to true was successful.</returns>
        public Task<bool> SetFirstResponderAlertTrueAsync(int firstResponderId);

        /// <summary>
        /// Deletes a first responder vitals. This is done when a first responder is changed to inactive.
        /// </summary>
        /// <param name="firstResponderId">The id of the target first responder.</param>
        /// <returns>Whether or not setting the first responder's vitals to null was successful.</returns>
        public Task<bool> DeleteFirstResponderVitalsAsync(int firstResponderId);

        /// <summary>
        /// Deletes a first responder location. This is done when a first responder is changed to inactive.
        /// </summary>
        /// <param name="firstResponderId">The id of the target first responder.</param>
        /// <returns>Whether or not setting the first responder's location to null was successful.</returns>
        public Task<bool> DeleteFirstResponderLocationAsync(int firstResponderId);

        /// <summary>
        /// Creates a location entry of a first responder.
        /// </summary>
        /// <param name="firstResponderId">The id of the first responder corresponding to the created location.</param>
        /// <param name="location">A <see cref="Location"/> object.</param>
        /// <returns>Whether or not the update was successful.</returns>
        public Task<bool> CreateFirstResponderLocationAsync(int firstResponderId, Location location);

        /// <summary>
        /// Creates a vitals entry for a first responder.
        /// </summary>
        /// <param name="firstResponderId">The id of the first responder corresponding to the created vitals.</param>
        /// <param name="vitals">A <see cref="Vitals"/> object.</param>
        /// <returns>Whether or not the update was successful.</returns>
        public Task<bool> CreateFirstResponderVitalsAsync(int firstResponderId, Vitals vitals);

        /// <summary>
        /// Updates the location of a first responder.
        /// </summary>
        /// <param name="firstResponderId">The id of the first responder to update.</param>
        /// <param name="location">A <see cref="Location"/> object.</param>
        /// <returns>Whether or not the update was successful.</returns>
        public Task<bool> UpdateFirstResponderLocationAsync(int firstResponderId, Location location);

        /// <summary>
        /// Updates the vitals of a first responder.
        /// </summary>
        /// <param name="firstResponderId">The id of the first responder to update.</param>
        /// <param name="vitals">A <see cref="Vitals"/> object.</param>
        /// <returns>Whether or not the update was successful.</returns>
        public Task<bool> UpdateFirstResponderVitalsAsync(int firstResponderId, Vitals vitals);

        /// <summary>
        /// Checks if first responder exists in the database based on worker ID.
        /// </summary>
        /// <param name="firstResponderId">The id of the first responder to check.</param>
        /// <returns>Whether or not the worker id exists in the worker table in the database.</returns>
        public Task<bool> FirstResponderExistsAsync(int firstResponderId);

        /// <summary>
        /// Checks if first responder is active.
        /// </summary>
        /// <param name="firstResponderId">The id of the first responder to check.</param>
        /// <returns>Whether or not the worker's active field is true in the database.</returns>
        public Task<bool> FirstResponderIsActiveAsync(int firstResponderId);

        /// <summary>
        /// Checks if first responder has an active alert.
        /// </summary>
        /// <param name="firstResponderId">The id of the first responder to check.</param>
        /// <returns>Whether or not the worker's alert field is true in the database.</returns>
        public Task<bool> FirstResponderHasAlertAsync(int firstResponderId);

        #endregion
    }
}
