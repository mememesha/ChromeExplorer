
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
            //var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
            //var bitmap = new Bitmap(assets.Open(new Uri("avares://Explorer.Avalonia.UI/Assets/folder_icon.png")));

            var drivingImage = new DrawingImage();
            if (value is DirectoryViewModel)
            {
                Image img = new Image();
             
                if (App.Current.TryFindResource("FolderIconImagePng", out object? resource))
                {
                    if (resource is IImage image)
                    {
                        return image;
                    }
                    if (resource is Image image2)
                    {
                        return image2.Source;
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
