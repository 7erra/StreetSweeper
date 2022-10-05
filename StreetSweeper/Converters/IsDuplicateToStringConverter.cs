using StreetSweeper.Core;
using System.Globalization;

namespace StreetSweeper.Converters
{
    internal class IsDuplicateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            PathItem p = (PathItem)value;
            return p.IsDuplicate() ? "D" : "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
