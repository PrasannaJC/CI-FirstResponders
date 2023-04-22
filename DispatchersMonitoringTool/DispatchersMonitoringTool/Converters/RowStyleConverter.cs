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
    internal class RowStyleConverter : IValueConverter
    {
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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
