using Explorer.Shared.ViewModels;
using System.Windows;

namespace Explorer.WPF.UI
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
