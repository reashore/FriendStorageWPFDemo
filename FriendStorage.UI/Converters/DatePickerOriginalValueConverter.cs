using System;
using System.Globalization;
using System.Windows.Data;

namespace FriendStorage.UI.Converters
{
    public class DatePickerOriginalValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? dateTime = (DateTime?) value;
            return dateTime?.ToString("dd-MM-yyyy") ?? value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
