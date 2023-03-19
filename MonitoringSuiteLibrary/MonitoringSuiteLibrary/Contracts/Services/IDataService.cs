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
        /// <summary>
        /// Gets a <see cref="IEnumerable{FirstResponder}"/> representing the first responders.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FirstResponder> GetFirstResponders();

        /// <summary>
        /// Updates an existing first responder.
        /// </summary>
        /// <param name="firstResponder">The first responder to update.</param>
        public void UpdateFirstResponder(FirstResponder firstResponder);

        /// <summary>
        /// Deletes an existing first responder.
        /// </summary>
        /// <param name="firstResponderId">The identifier of the first responder to delete.</param>
        public void DeleteFirstResponder(int firstResponderId);

        /// <summary>
        /// Adds a first responder.
        /// </summary>
        /// <param name="firstResponder">The <see cref="FirstResponder"/> to add.</param>
        public void AddFirstResponder(FirstResponder firstResponder);
    }
}
