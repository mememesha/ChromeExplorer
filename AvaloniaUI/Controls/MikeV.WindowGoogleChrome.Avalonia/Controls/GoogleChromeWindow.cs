
using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;
using System;

namespace MikeV.WindowGoogleChrome.Avalonia
{
    public class GoogleChromeWindow:Window,IStyleable
    {
        Type IStyleable.StyleKey => typeof(GoogleChromeWindow);

        public static StyledProperty<object> ToolBarContentProperty = AvaloniaProperty.Register<GoogleChromeWindow, object>(nameof(ToolBarContent));
        public object ToolBarContent
        {
            get => GetValue(ToolBarContentProperty);
            set => SetValue(ToolBarContentProperty, value);
        }
        public GoogleChromeWindow()
        {

        }
    }
}
