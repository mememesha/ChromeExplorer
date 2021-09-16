using System.ComponentModel;
using Explorer.Shared.ViewModels;
using System.Windows;

namespace Explorer.WPF.UI
{

    public partial class MainWindow
    {
        private MainViewModel _mainVm;
        public MainWindow()
        {
            InitializeComponent();

            _mainVm = new MainViewModel();
            DataContext = _mainVm;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _mainVm.ApplicationClosing();
            Application.Current.Shutdown();
        }
        
    }
}
