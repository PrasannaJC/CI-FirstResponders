using MonitoringSuiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileVitalsMonitoringTool.Contracts.Services
{
    /// <summary>
    /// An interface for getting vitals data.
    /// </summary>
    public interface IVitalsData
    {
        /// <summary>
        /// Gets the vitals data.
        /// </summary>
        /// <returns>The Vitals.</returns>
        public Vitals GetVitals();
    }
}
