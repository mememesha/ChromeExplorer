
using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Explorer.Shared.Components;
using Explorer.Shared.ViewModels;
using SharpVectors.Converters;
using SharpVectors.Renderers.Wpf;

namespace Explorer.WPF.UI
{
    public class FileEntityToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var drivingImage = new DrawingImage();

            if (!(value is FileEntityViewModel viewModel))
                return drivingImage;

            var imagePath = ChromerExpr.Instance.IconsManager.GetIconPath(viewModel);

            if (imagePath.Extension.ToUpper() == ".SVG")
            {
                var sesttings = new WpfDrawingSettings()
                {
                    TextAsGeometry = false,
                    IncludeRuntime = true,
                };
                var converter = new FileSvgReader(sesttings);
                var drawing = converter.Read(imagePath.FullName);
                if (drawing != null)
                    return new DrawingImage(drawing);
            }
            else
            {
                var bitmapSource = new BitmapImage(new Uri(imagePath.FullName));
                return bitmapSource;
            }

            return drivingImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
