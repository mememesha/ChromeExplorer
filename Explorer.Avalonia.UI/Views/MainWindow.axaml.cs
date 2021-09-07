using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Explorer.Shared.ViewModels;

namespace Explorer.Avalonia.UI.Views
{
    public partial class MainWindow : Window
    {
        private MainViewModel _mainVm;
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            _mainVm = new MainViewModel();
            DataContext = _mainVm;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainVm.ApplicationClosing();
            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime
                desktopStyleApplicationLifetime)
            {
                desktopStyleApplicationLifetime.Shutdown();
            }
        }

        private void ExpandButton_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState switch
            {
                WindowState.Maximized => WindowState.Normal,
                WindowState.Normal => WindowState.Maximized,
                _ => WindowState
            };
        }

        private void CollapseButton_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
