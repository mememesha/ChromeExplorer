
using System;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Media;
using Explorer.Shared.ViewModels;

namespace Explorer.Avalonia.UI
{
    public class FileEntityToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var drivingImage = new DrawingImage();
            if (value is DirectoryViewModel)
            {
                Image img = new Image();
             
                if (App.Current.TryFindResource("FolderIconImage", out object? resource))
                {
                    if (resource is IImage image)
                    {
                        return image;
                    }
                }
            }
            else if (value is FileViewModel)
            {
                if (App.Current.TryFindResource("DocumentIconImage", out object? resource))
                {
                    if (resource is IImage image)
                    {
                        return image;
                    }
                }
            }
            return (IImage)drivingImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
