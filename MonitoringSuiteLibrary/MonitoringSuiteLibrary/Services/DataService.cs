using MonitoringSuiteLibrary.Contracts.Services;
using MonitoringSuiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;

namespace MonitoringSuiteLibrary.Services
{
    /// <summary>
    /// Concrete implementation of the first responder data service.
    /// </summary>
    public class DataService : IDataService
    {
        #region Private Fields 

        private readonly IOptions<DataServiceConfiguration> _options;

        #endregion

        #region Constructors

        public DataService(IOptions<DataServiceConfiguration> options)
        {
            _options = options;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// TODO: Add description and implement <see cref="GetFirstResponders"/>.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<FirstResponder> GetFirstResponders()
        {
            // TODO: Remove example usage of _options.
            var setOptions = _options.Value;
            string connectionString = setOptions.ConnectionString;

            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO: Add description and implement <see cref="GetFirstResponders(int)"/>.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<FirstResponder> GetFirstResponders(int eventId)
        {
            // TODO: We may need to be able to GetFirstResponders for a specific event.
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO: Add description and implement <see cref="GetFirstResponderVitals(int)"/>.
        /// </summary>
        /// <param name="firstResponderId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Vitals GetFirstResponderVitals(int firstResponderId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO: Add description and implement <see cref="GetFirstResponderLocation(int)"/>.
        /// </summary>
        /// <param name="firstResponderId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Location GetFirstResponderLocation(int firstResponderId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO: Add description and implement <see cref="SetFirstResponderInactive(int)"/>
        /// </summary>
        /// <param name="firstResponderId"></param>
        /// <returns>Whether or not setting the first responder as inactive was successful.</returns>
        public bool SetFirstResponderInactive(int firstResponderId)
        {
            // TODO: Should somehow clear out the vitals and location information. 
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO: Add description and implement <see cref="SetFirstResponderActive(int, Vitals, Location)"/>.
        /// </summary>
        /// <param name="firstResponderId">The id of the target first responder.</param>
        /// <param name="vitals">The initial vitals data to store for the first responder.</param>
        /// <param name="location">The initial location data to store for the first responder.</param>
        /// <returns>Whether or not setting the first responder as active was successful.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool SetFirstResponderActive(int firstResponderId, Vitals vitals, Location location)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO: Add description and implement <see cref="UpdateFirstResponderLocation(int)"/>.
        /// </summary>
        /// <param name="firstResponderId"></param>
        /// <param name="location"></param>
        /// <returns>Whether or not the update was successful.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool UpdateFirstResponderLocation(int firstResponderId, Location location)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO: Add description and implement <see cref="UpdateFirstResponderVitals(int)"/>.
        /// </summary>
        /// <param name="firstResponderId"></param>
        /// <param name="vitals"></param>
        /// <returns>Whether or not the update was successful.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool UpdateFirstResponderVitals(int firstResponderId, Vitals vitals)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
