using Microsoft.Maui.Controls;
using StreetSweeper.Core;
using StreetSweeper.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetSweeper.Converters
{
    class PathItemToColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length == 0 || values.Any(x => x == null)) return MainPageViewModel.ValidPathItemColor;
            PathItem pathItem = (PathItem)values[0];
            var doRemoveDuplicates = (bool)values[1];
            var doRemoveDeleted = (bool)values[2];
            if (doRemoveDuplicates && pathItem.IsDuplicate()) return MainPageViewModel.DuplicatePathItemColor;
            if (doRemoveDeleted && !pathItem.PathExists()) return MainPageViewModel.DeletedPathItemColor;
            return MainPageViewModel.ValidPathItemColor;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
