using MonitoringSuiteLibrary.Contracts.Services;
using MonitoringSuiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

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
        /// Asynchronous function that queries the database to retrieve all first responder's information from the workers table along with
        /// their corresponding vitals and location.
        /// </summary>
        /// <returns>
        /// A collection of FirstResponder objects
        /// </returns>
        public async Task<IEnumerable<FirstResponder>> GetFirstRespondersAsync()
        {
            await Task.CompletedTask;

            List<FirstResponder> firstResponders = new List<FirstResponder>();

            var setOptions = _options.Value;
            string connectionString = setOptions.ConnectionString;

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("Select * from workers", connection);

                MySqlConnector.MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int firstResponderId = reader.GetInt32(0);
                    Vitals? vitals = await GetFirstResponderVitalsAsync(firstResponderId);
                    Location? location = await GetFirstResponderLocationAsync(firstResponderId);

                    firstResponders.Add(new FirstResponder(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetChar(4),
                        reader.GetDouble(5), reader.GetInt32(6), reader.GetBoolean(7), reader.GetBoolean(8), vitals, location));

                }
            }
            return firstResponders;
        }

        /// <summary>
        /// Asynchronous function that queries the database to retrieve a first responder's information from the workers table along with
        /// their corresponding vitals and location.
        /// </summary>
        /// <param name="firstResponderId">The unique id of the first responder</param>
        /// <returns>
        /// A FirstResponder object
        /// </returns>
        public async Task<FirstResponder?> GetFirstResponderAsync(int firstResponderId)
        {
            await Task.CompletedTask;

            FirstResponder firstResponder;
            var setOptions = _options.Value;
            string connectionString = setOptions.ConnectionString;

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("Select * from workers where w_id=" + firstResponderId.ToString(), connection);

                MySqlConnector.MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Vitals? vitals = await GetFirstResponderVitalsAsync(firstResponderId);
                    Location? location = await GetFirstResponderLocationAsync(firstResponderId);

                    firstResponder = new FirstResponder(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetChar(4),
                        reader.GetDouble(5), reader.GetInt32(6), reader.GetBoolean(7), reader.GetBoolean(8), vitals, location);

                    return firstResponder;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Asynchrnous function that queries the database to retrieve all first responder's information from the workers table
        /// that responded to a particular event along with their corresponding vitals and location.
        /// </summary>
        /// <returns>
        /// A collection of FirstResponder objects
        /// </returns>
        public async Task<IEnumerable<FirstResponder>> GetFirstRespondersAsync(int eventId)
        {
            await Task.CompletedTask;

            List<FirstResponder> firstResponders = new List<FirstResponder>();

            var setOptions = _options.Value;
            string connectionString = setOptions.ConnectionString;

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("Select * from responds where e_id=" + eventId.ToString(), connection);

                MySqlConnector.MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int firstResponderId = reader.GetInt32(1);

                    FirstResponder? firstResponder = await GetFirstResponderAsync(firstResponderId);

                    firstResponders.Add(firstResponder);

                }
            }
            return firstResponders;
        }

        /// <summary>
        /// Asynchrnous function that queries the database to retrieve the vitals entry of a first responder.
        /// </summary>
        /// <param name="firstResponderId">The unique id of the first responder</param>
        /// <returns>
        /// A Vitals object
        /// </returns>
        public async Task<Vitals?> GetFirstResponderVitalsAsync(int firstResponderId)
        {
            await Task.CompletedTask;

            Vitals vitals;
            var setOptions = _options.Value;
            string connectionString = setOptions.ConnectionString;

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("Select * from vitals where w_id=" + firstResponderId.ToString(), connection);

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
        }

        /// <summary>
        /// Asynchrnous function that queries the database to retrieve the location entry of a first responder.
        /// </summary>
        /// <param name="firstResponderId">The unique id of the first responder</param>
        /// <returns>
        /// A location object
        /// </returns>
        public async Task<Location?> GetFirstResponderLocationAsync(int firstResponderId)
        {
            await Task.CompletedTask;

            Location location;
            var setOptions = _options.Value;
            string connectionString = setOptions.ConnectionString;

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("Select * from locations where w_id=" + firstResponderId.ToString(), connection);

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
        }

        /// <summary>
        /// Modifies a first responder's active status to false
        /// </summary>
        /// <param name="firstResponderId"></param>
        /// <returns>Whether or not setting the first responder as inactive was successful.</returns>
        public async Task<bool> SetFirstResponderInactiveAsync(int firstResponderId)
        {
            await Task.CompletedTask;

            var setOptions = _options.Value;
            string connectionString = setOptions.ConnectionString;

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("update workers set active = false where w_id =" + firstResponderId.ToString(), connection);

                    int rowCount = command.ExecuteNonQuery();

                    return (rowCount == 1) ? true : false;

                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// TODO: Add description and implement <see cref="SetFirstResponderActive(int, Vitals, Location)"/>.
        /// </summary>
        /// <param name="firstResponderId">The id of the target first responder.</param>
        /// <param name="vitals">The initial vitals data to store for the first responder.</param>
        /// <param name="location">The initial location data to store for the first responder.</param>
        /// <returns>Whether or not setting the first responder as active was successful.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> SetFirstResponderActiveAsync(int firstResponderId, Vitals vitals, Location location)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO: Add description and implement <see cref="UpdateFirstResponderLocation(int)"/>.
        /// </summary>
        /// <param name="firstResponderId"></param>
        /// <param name="location"></param>
        /// <returns>Whether or not the update was successful.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> UpdateFirstResponderLocationAsync(int firstResponderId, Location location)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO: Add description and implement <see cref="UpdateFirstResponderVitals(int)"/>.
        /// </summary>
        /// <param name="firstResponderId"></param>
        /// <param name="vitals"></param>
        /// <returns>Whether or not the update was successful.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> UpdateFirstResponderVitalsAsync(int firstResponderId, Vitals vitals)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        #endregion
    }
}
