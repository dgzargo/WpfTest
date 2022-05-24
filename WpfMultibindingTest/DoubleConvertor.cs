using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfMultibindingTest;

public class DoubleConvertor : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not double doubleValue)
        {
            return DependencyProperty.UnsetValue;
        }

        return doubleValue.ToString("0.########", CultureInfo.InvariantCulture);
    }

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not string stringValue)
        {
            return null;
        }
        
        var parsed = double.TryParse(stringValue, NumberStyles.Any, CultureInfo.InvariantCulture, out var doubleValue);
        return parsed ? doubleValue : null;
    }
}