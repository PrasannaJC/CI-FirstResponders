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
        /// Gets a <see cref="IEnumerable{FirstResponder}"/> representing the first responders.
        /// </summary>
        /// <returns>An IEnumerable of all first responders.</returns>
        public Task<IEnumerable<FirstResponder>> GetFirstRespondersAsync();

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
        /// Creates first responder location entry.
        /// </summary>
        /// <param name="firstResponderId">The id of the first responder to update.</param>
        /// <returns>Whether or not the update was successful.</returns>
        public Task<bool> CreateFirstResponderLocationAsync(int firstResponderId);

        /// <summary>
        /// Creates first responder vitals entry.
        /// </summary>
        /// <param name="firstResponderId">The id of the first responder to update.</param>
        /// <returns>Whether or not the update was successful.</returns>
        public Task<bool> CreateFirstResponderVitalsAsync(int firstResponderId);

        /// <summary>
        /// Updates first responder location.
        /// </summary>
        /// <param name="firstResponderId">The id of the first responder to update.</param>
        /// <param name="xcoord">The x coordinate of the location</param>
        /// <param name="ycoord">The y coordinate of the location</param>
        /// <param name="zcoord">The z coordinate of the location</param>
        /// <returns>Whether or not the update was successful.</returns>
        public Task<bool> UpdateFirstResponderLocationAsync(int firstResponderId, decimal xcoord, decimal ycoord, decimal zcoord);

        /// <summary>
        /// Updates first responder vitals.
        /// </summary>
        /// <param name="firstResponderId">The id of the first responder to update.</param>
        /// <param name="bloodoxy">The blood oxygen level.</param>
        /// <param name="heartrate">The heart rate level.</param>
        /// <param name="sysbp">The Systolic blood pressure level.</param>
        /// <param name="diabp">The diastolic blood pressure level.</param>
        /// <param name="resprate">The respiratory rate.</param>
        /// <param name="tempf">The body temperature in fahrenheit.</param>
        /// <returns>Whether or not the update was successful.</returns>
        public Task<bool> UpdateFirstResponderVitalsAsync(int firstResponderId, int bloodoxy, int heartrate, int sysbp, int diabp, int resprate, int tempf);

        /// <summary>
        /// Checks if first responder exists in the database based on worker ID.
        /// </summary>
        /// <param name="firstResponderId">The id of the first responder to update.</param>
        /// <returns>Whether or not the worker id exists in the worker table in the database.</returns>
        public Task<bool> FirstResponderExistsAsync(int firstResponderId);

        #endregion
    }
}
