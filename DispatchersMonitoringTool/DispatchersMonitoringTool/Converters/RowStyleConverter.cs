using MonitoringSuiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DispatchersMonitoringTool.Converters
{
    /// <summary>
    /// Converts a first responder alert to a color for UI representation.
    /// </summary>
    public class RowStyleConverter : IValueConverter
    {
        /// <summary>
        /// Converts first responder alert to a color.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">Required parameter for <see cref="IValueConverter"/>. Not used.</param>
        /// <param name="parameter">Required parameter for <see cref="IValueConverter"/>. Not used.</param>
        /// <param name="culture">Required parameter for <see cref="IValueConverter"/>. Not used.</param>
        /// <returns>A string representing the color the alert was converted to.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if((value as FirstResponder).Alert == true)
            {
                return "Red";
            }
            else if ((value as FirstResponder).IsVitalsAndLocationCurrent == false)
            {
                return "Orange";
            }
            else
            {
                return "Green";
            }
        }

        /// <summary>
        /// Not used.
        /// </summary>
        /// <param name="value">N/A</param>
        /// <param name="targetType">N/A</param>
        /// <param name="parameter">N/A</param>
        /// <param name="culture">N/A</param>
        /// <returns>N/A</returns>
        /// <exception cref="NotImplementedException">Occurs when called.</exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
