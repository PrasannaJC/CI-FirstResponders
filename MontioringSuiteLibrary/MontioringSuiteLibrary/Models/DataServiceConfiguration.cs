using System;
using System.Collections.Generic;
using System.Text;

namespace MontioringSuiteLibrary.Models
{
    /// <summary>
    /// Stores the configuration information to be provided by the app using this library.
    /// </summary>
    public class DataServiceConfiguration
    {
        /// <summary>
        /// The connection string for the first responder database.
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
