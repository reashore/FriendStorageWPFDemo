﻿using FriendStorage.UI.DataProvider.Lookups;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace FriendStorage.UI.Converters
{
    public class ComboBoxOriginalValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int id = (int)value;
            ComboBox comboBox = parameter as ComboBox;
            if (comboBox != null && comboBox.ItemsSource != null)
            {
                LookupItem lookupItem
                  = comboBox.ItemsSource.OfType<LookupItem>().SingleOrDefault(l => l.Id == id);
                if (lookupItem != null)
                {
                    return lookupItem.DisplayValue;
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
