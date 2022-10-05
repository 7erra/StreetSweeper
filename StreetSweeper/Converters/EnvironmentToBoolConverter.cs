using StreetSweeper.Core;
using System.Globalization;

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
