
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Explorer.Shared.ViewModels;

namespace Explorer.WPF.UI
{
    public class FileEntityToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var drivingImage = new DrawingImage();
            if (value is DirectoryViewModel)
            {
                var resource = App.Current.TryFindResource("FolderIconImage");
                if (resource is not ImageSource directoryImageSource) return drivingImage;
                return directoryImageSource;
            }
            else if(value is FileViewModel)
            {
                var resource = App.Current.TryFindResource("DocumentIconImage");
                if (resource is not ImageSource fileImageSource) return drivingImage;
                return fileImageSource;
            }
            return drivingImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
