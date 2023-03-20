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
            List<FirstResponder> firstResponders = new List<FirstResponder>();

            var setOptions = _options.Value;
            string connectionString = setOptions.ConnectionString;

            MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString);
            connection.Open();
            MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("Select * from workers", connection);
            connection.Close();

            MySqlConnector.MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int firstResponderId = reader.GetInt32(0);
                Vitals? vitals = GetFirstResponderVitals(firstResponderId);
                Location? location = GetFirstResponderLocation(firstResponderId);

                firstResponders.Add(new FirstResponder(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetChar(4),
                    reader.GetDouble(5), reader.GetInt32(6), reader.GetBoolean(7), vitals, location));

            }
            return firstResponders;
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
        /// 
        /// </summary>
        /// <param name="firstResponderId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Vitals? GetFirstResponderVitals(int firstResponderId)
        {
            Vitals vitals;
            var setOptions = _options.Value;
            string connectionString = setOptions.ConnectionString;

            MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString);
            connection.Open();
            MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("Select * from vitals where w_id="+firstResponderId.ToString(), connection);
            connection.Close();

            MySqlConnector.MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                vitals = new Vitals(reader.GetDateTime(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7));

                return vitals;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstResponderId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Location? GetFirstResponderLocation(int firstResponderId)
        {
            Location location;
            var setOptions = _options.Value;
            string connectionString = setOptions.ConnectionString;

            MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString);
            connection.Open();
            MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("Select * from locations where w_id=" + firstResponderId.ToString(), connection);
            connection.Close();

            MySqlConnector.MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                location = new Location(reader.GetDateTime(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetDecimal(4));

                return location;
            }
            else
            {
                return null;
            }
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
