using System;
using Avalonia.Controls;
using Avalonia.Styling;

namespace MikeV.WindowGoogleChrome.Avalonia
{
    public class ChromeTabsControl : ListBox, IStyleable
    {
        Type IStyleable.StyleKey => typeof(ChromeTabsControl);
    }
}
