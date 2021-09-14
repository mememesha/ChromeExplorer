
using System.Windows;

namespace Explorer.WPF.UI
{
    internal class Windows
    {
        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.RegisterAttached(
            name: "IsActive", propertyType: typeof(bool), ownerType: typeof(Windows), defaultMetadata: new PropertyMetadata(default(bool)));

        public static void SetIsActive(DependencyObject element, bool value)
        {
            element.SetValue(IsActiveProperty, value);
        }

        public static bool GetIsActive(DependencyObject element)
        {
            return (bool)element.GetValue(IsActiveProperty);
        }

        public static readonly DependencyProperty WindowsStateProperty = DependencyProperty.RegisterAttached(
            name: "WindowsState", propertyType: typeof(WindowState), ownerType: typeof(Windows), defaultMetadata: new PropertyMetadata(default(WindowState)));

        public static void SetWindowsState(DependencyObject element, WindowState value)
        {
            element.SetValue(WindowsStateProperty, value);
        }

        public static WindowState GetWindowsState(DependencyObject element)
        {
            return (WindowState)element.GetValue(WindowsStateProperty);
        }
    }
}
