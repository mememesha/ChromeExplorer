﻿
using System;
using System.Globalization;
using System.Windows;

namespace Explorer.WPF.UI
{
    internal class WindowTitleHeightConverter : ConvertorBase<WindowTitleHeightConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is WindowState windowState)
            {
                return windowState == WindowState.Normal?42:32;
            }
            return 42;
        }
    }
}
