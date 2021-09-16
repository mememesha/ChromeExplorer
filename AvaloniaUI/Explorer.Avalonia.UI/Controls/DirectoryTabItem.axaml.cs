using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Explorer.Avalonia.UI
{
    public partial class DirectoryTabItem : UserControl
    {
        public DirectoryTabItem()
        {
            InitializeComponent();
        }
        
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
