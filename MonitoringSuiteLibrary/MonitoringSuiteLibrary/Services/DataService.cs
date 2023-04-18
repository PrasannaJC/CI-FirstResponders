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
        /// Asynchronous function that queries the database to retrieve all active first responder's information from the workers table along with
        /// their corresponding vitals and location.
        /// </summary>
        /// <returns>
        /// A collection of FirstResponder objects
        /// </returns>
        public async Task<IEnumerable<FirstResponder>> GetActiveFirstRespondersAsync()
        {
            await Task.CompletedTask;

            List<FirstResponder> firstResponders = new List<FirstResponder>();

            var setOptions = _options.Value;
            string connectionString = setOptions.ConnectionString;

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("Select * from workers WHERE active = 1", connection);

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

            //await DeleteFirstResponderLocationAsync(firstResponderId);
            await DeleteFirstResponderVitalsAsync(firstResponderId);

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
        /// Modifies a first responder's active status to true
        /// </summary>
        /// <param name="firstResponderId"></param>
        /// <returns>Whether or not setting the first responder as inactive was successful.</returns>
        public async Task<bool> SetFirstResponderActiveAsync(int firstResponderId)
        {
            await Task.CompletedTask;

            var setOptions = _options.Value;
            string connectionString = setOptions.ConnectionString;

            //await CreateFirstResponderLocationAsync(firstResponderId);
            //await CreateFirstResponderVitalsAsync(firstResponderId);

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("update workers set active = true where w_id =" + firstResponderId.ToString(), connection);

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
        /// Sets a first responder alert status as false.
        /// </summary>
        /// <param name="firstResponderId">The id of the target first responder.</param>
        /// <returns>Whether or not setting the first responder's alert to false was successful.</returns>
        public async Task<bool> SetFirstResponderAlertFalseAsync(int firstResponderId)
        {
            await Task.CompletedTask;

            var setOptions = _options.Value;
            string connectionString = setOptions.ConnectionString;

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("update workers set alert = false where w_id =" + firstResponderId.ToString(), connection);

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
        /// Sets a first responder alert status as true.
        /// </summary>
        /// <param name="firstResponderId">The id of the target first responder.</param>
        /// <returns>Whether or not setting the first responder's alert to true was successful.</returns>
        public async Task<bool> SetFirstResponderAlertTrueAsync(int firstResponderId)
        {
            await Task.CompletedTask;

            var setOptions = _options.Value;
            string connectionString = setOptions.ConnectionString;

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("update workers set alert = true where w_id =" + firstResponderId.ToString(), connection);

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
        /// Deletes a first responder vitals. This is done when a first responder is changed to inactive.
        /// </summary>
        /// <param name="firstResponderId"></param>
        /// <returns>Whether or not setting the first responder as inactive was successful.</returns>
        public async Task<bool> DeleteFirstResponderVitalsAsync(int firstResponderId)
        {
            await Task.CompletedTask;

            var setOptions = _options.Value;
            string connectionString = setOptions.ConnectionString;

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("delete from vitals where w_id =" + firstResponderId.ToString(), connection);

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
        /// Deletes a first responder location. This is done when a first responder is changed to inactive.
        /// </summary>
        /// <param name="firstResponderId"></param>
        /// <returns>Whether or not setting the first responder as inactive was successful.</returns>
        public async Task<bool> DeleteFirstResponderLocationAsync(int firstResponderId)
        {
            await Task.CompletedTask;

            var setOptions = _options.Value;
            string connectionString = setOptions.ConnectionString;

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("delete from locations where w_id =" + firstResponderId.ToString(), connection);

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
        /// Creates a location entry of a first responder.
        /// </summary>
        /// <param name="firstResponderId"></param>
        /// <param name="xcoord"></param>
        /// <param name="ycoord"></param>
        /// <param name="zcoord"></param>
        /// <returns>Whether or not the update was successful.</returns>
        public async Task<bool> CreateFirstResponderLocationAsync(int firstResponderId, decimal xcoord, decimal ycoord, decimal zcoord)
        {
            await Task.CompletedTask;

            var setOptions = _options.Value;
            string connectionString = setOptions.ConnectionString;

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(
                        "insert into locations (w_id, xcoord, ycoord, zcoord) values ("
                        + firstResponderId.ToString() + ", "
                        + xcoord.ToString() + ", "
                        + ycoord.ToString() + ", "
                        + zcoord.ToString() + " )", connection);

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
        /// Creates a vitals entry for a first responder.
        /// </summary>
        /// <param name="firstResponderId"></param>
        /// <param name="bloodoxy"></param>
        /// <param name="heartrate"></param>
        /// <param name="sysbp"></param>
        /// <param name="diabp"></param>
        /// <param name="resprate"></param>
        /// <param name="tempf"></param>
        /// <returns>Whether or not the update was successful.</returns>
        public async Task<bool> CreateFirstResponderVitalsAsync(int firstResponderId, int bloodoxy, int heartrate, int sysbp, int diabp, int resprate, int tempf)
        {
            await Task.CompletedTask;

            var setOptions = _options.Value;
            string connectionString = setOptions.ConnectionString;

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(
                        "insert into vitals (w_id, bloodoxy, heartrate, sysbp, diabp, resprate, tempf) values ("
                        + firstResponderId.ToString() + ", "
                        + bloodoxy.ToString() + ", "
                        + heartrate.ToString() + ", "
                        + sysbp.ToString() + ", "
                        + diabp.ToString() + ", "
                        + resprate.ToString() + ", "
                        + tempf.ToString() + ")", connection);

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
        /// Updates the location of a first responder.
        /// </summary>
        /// <param name="firstResponderId"></param>
        /// <param name="xcoord"></param>
        /// <param name="ycoord"></param>
        /// <param name="zcoord"></param>
        /// <returns>Whether or not the update was successful.</returns>
        public async Task<bool> UpdateFirstResponderLocationAsync(int firstResponderId, decimal xcoord, decimal ycoord, decimal zcoord)
        {
            await Task.CompletedTask;

            var setOptions = _options.Value;
            string connectionString = setOptions.ConnectionString;

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(
                        "update locations set " +
                        "xcoord = " + xcoord.ToString() + ", " +
                        "ycoord = " + ycoord.ToString() + ", " +
                        "zcoord = " + zcoord.ToString() + " " +
                        "where w_id = " + firstResponderId.ToString(), connection);

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
        /// Updates the location of a first responder.
        /// </summary>
        /// <param name="firstResponderId"></param>
        /// <param name="bloodoxy"></param>
        /// <param name="heartrate"></param>
        /// <param name="sysbp"></param>
        /// <param name="diabp"></param>
        /// <param name="resprate"></param>
        /// <param name="tempf"></param>
        /// <returns>Whether or not the update was successful.</returns>
        public async Task<bool> UpdateFirstResponderVitalsAsync(int firstResponderId, int bloodoxy, int heartrate, int sysbp, int diabp, int resprate, int tempf)
        {
            await Task.CompletedTask;

            var setOptions = _options.Value;
            string connectionString = setOptions.ConnectionString;

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(
                        "update vitals set " +
                        "bloodoxy = " + bloodoxy.ToString() + ", " +
                        "heartrate = " + heartrate.ToString() + ", " +
                        "sysbp = " + sysbp.ToString() + ", " +
                        "diabp = " + diabp.ToString() + ", " +
                        "resprate = " + resprate.ToString() + ", " +
                        "tempf = " + tempf.ToString() + " " +
                        "where w_id = " + firstResponderId.ToString(), connection);

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
        /// Checks if first responder exists in the database based on worker ID.
        /// </summary>
        /// <param name="firstResponderId">The id of the first responder to update.</param>
        /// <returns>Whether or not the worker id exists in the worker table in the database.</returns>
        public async Task<bool> FirstResponderExistsAsync(int firstResponderId)
        {
            await Task.CompletedTask;

            var data = await GetFirstResponderAsync(firstResponderId);

            if (data == null)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
