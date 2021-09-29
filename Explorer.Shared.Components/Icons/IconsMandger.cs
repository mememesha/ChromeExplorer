
using System;
using System.IO;
using Explorer.Shared.ViewModels;

namespace Explorer.Shared.Components
{
    internal class IconsManedger: IIconsManager
    {
        private readonly ExtentionToImageFileConverter _converter;

        public IconsManedger(ExtentionToImageFileConverter converter)
        {
            _converter = converter;
        }
        public FileInfo GetIconPath(FileEntityViewModel viewModel)
        {
            if (viewModel is DirectoryViewModel)
            {
                return _converter.GetImagePath(string.Empty);
            }
            else if (viewModel is FileViewModel fileViewModel)
            {
                var extention = Path.GetExtension(fileViewModel.FullName);

                var imagePath = _converter.GetImagePath(extention);

                return imagePath;
            }
            throw new NotImplementedException();
        }
    }

    public interface IIconsManager
    {
        FileInfo GetIconPath(FileEntityViewModel viewModel);
    }
}
