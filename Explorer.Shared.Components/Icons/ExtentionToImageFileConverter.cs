
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Explorer.Shared.Components
{
    internal class ExtentionToImageFileConverter
    {
        public FileInfo GetImagePath(string extention)
        {
            var applicationDirectory = AppDomain.CurrentDomain.BaseDirectory;

            var iconsDirectory =
                new DirectoryInfo(Path.Combine(applicationDirectory, "Resources", "Icons", "high-contrast"));

            var map = iconsDirectory.GetFiles().ToDictionary(key =>Path.GetFileNameWithoutExtension(key.Name), value => value.FullName);

            if(map.ContainsKey(extention.Trim('.')))
            {
                var path = map[extention.Trim('.')];

                return new FileInfo(path);
            }

            if(extention == string.Empty)
                return new FileInfo(map["folder-neon"]);

            return new FileInfo(map["in"]);
        }
    }

  
}
