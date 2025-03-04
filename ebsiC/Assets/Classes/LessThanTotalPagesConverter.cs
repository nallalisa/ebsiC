using System;
using System.Globalization;
using System.Windows.Data;

namespace ebsiC.Assets.Classes
{
    public class LessThanTotalPagesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int totalPages = parameter as int? ?? 1;
            return value is int intValue && intValue < totalPages;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
