using MontioringSuiteLibrary.Contracts.Services;
using MontioringSuiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;

namespace MontioringSuiteLibrary.Services
{
    /// <summary>
    /// Concrete implementation of the first responder data service.
    /// </summary>
    public class DataService : IDataService
    {
        private readonly IOptions<DataServiceConfiguration> _options;

        public DataService(IOptions<DataServiceConfiguration> options)
        {
            _options = options;
        }

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
        /// TODO: Add description and implement <see cref="AddFirstResponder(FirstResponder)"/>.
        /// </summary>
        /// <param name="firstResponder"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void AddFirstResponder(FirstResponder firstResponder)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO: Add description and implement <see cref="DeleteFirstResponder(FirstResponder)"/>.
        /// </summary>
        /// <param name="firstResponder"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void DeleteFirstResponder(int firstResponderId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO: Add description and implement <see cref="UpdateFirstResponder(FirstResponder)"/>.
        /// </summary>
        /// <param name="firstResponder"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void UpdateFirstResponder(FirstResponder firstResponder)
        {
            throw new NotImplementedException();
        }
    }
}
