using System;
using System.Windows.Data;
using System.Windows;
using System.Globalization;

namespace PostViewerTool.ViewModel.Base
{
    /// <summary>
    /// This class represents the Value converter for data bindings
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
