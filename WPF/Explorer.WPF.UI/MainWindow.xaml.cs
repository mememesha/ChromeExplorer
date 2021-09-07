using Explorer.Shared.ViewModels;
using System.Windows;

namespace Explorer.WPF.UI
{

    public partial class MainWindow : Window
    {
        private MainViewModel _mainVm;
        public MainWindow()
        {
            InitializeComponent();

            _mainVm = new MainViewModel();

            DataContext = _mainVm;
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainVm.ApplicationClosing();
            Application.Current.Shutdown();
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
