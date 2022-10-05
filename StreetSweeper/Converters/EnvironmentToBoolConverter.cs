using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using StreetSweeper.Core;

namespace StreetSweeper.Converters
{
    internal class EnvironmentToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return false;
            var environment = (EnvironmentVariableTarget)value;

            if (environment == EnvironmentVariableTarget.Machine)
            {
                return Tools.IsAdmin();
            }

            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
