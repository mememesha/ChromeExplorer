using System;
using System.Globalization;
using System.Windows;

namespace MikeV.WindowGoogleChrome.Wpf
{
    public class WindowBorderThicknesConverter : ConvertorBase<WindowBorderThicknesConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double length = 1;
            if (parameter is string lengthString)
            {
                double.TryParse(lengthString, out length);
            }

            if (value is WindowState windowState)
            {
                return windowState == WindowState.Normal
                    ? new Thickness(length)
                    : new Thickness(0);
            }
            

            return new Thickness(0);
        }
    }
}