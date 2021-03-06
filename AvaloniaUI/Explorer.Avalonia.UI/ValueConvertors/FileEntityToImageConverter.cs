
using System;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Explorer.Shared.Components;
using Explorer.Shared.ViewModels;
using Svg;

namespace Explorer.Avalonia.UI
{
    public class FileEntityToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Bitmap drivingImage = null;

            if (!(value is FileEntityViewModel viewModel))
                return drivingImage;

            var imagePath = ChromerExpr.Instance.IconsManager.GetIconPath(viewModel);

            if (imagePath.Extension.ToUpper() == ".SVG")
            {
                var svgDocument = SvgDocument.Open(imagePath.FullName);
               
                if (svgDocument != null)
                {
                    var bitmap = svgDocument.Draw();

                    using var stream = new MemoryStream();

                    bitmap.Save(stream,ImageFormat.Png);
                    stream.Seek(0, SeekOrigin.Begin);

                    return new Bitmap(stream);
                }
            }
            else
            {
                return new Bitmap(imagePath.FullName);
            }

            return drivingImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
