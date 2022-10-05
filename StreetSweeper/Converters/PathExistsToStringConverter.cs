using StreetSweeper.Core;
using System.Globalization;

namespace StreetSweeper.Converters
{
    class PathExistsToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            PathItem item = (PathItem)value;
            return item.PathExists() ? "" : "X";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
