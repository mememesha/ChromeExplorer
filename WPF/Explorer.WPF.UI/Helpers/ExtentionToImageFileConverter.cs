
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Explorer.WPF.UI
{
    internal static class ExtentionToImageFileConverter
    {
        private static readonly IconsSettings _settings;

        static ExtentionToImageFileConverter()
        {
            _settings = IconsSettings.IconsOpen("icons.json");
        }
        public static FileInfo GetImagePath(string extention)
        {
            var applicationDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if(_settings.Icons.ContainsKey(extention))
            {
                var path = _settings.Icons[extention];
                return new FileInfo(Path.Combine(applicationDirectory, "Icons", path));
            }

            return new FileInfo(Path.Combine(applicationDirectory, "Icons", "086-file-50.svg"));
        }
    }

    public class IconsSettings
    {
        public Dictionary<string, string> Icons { get; set; } = new Dictionary<string, string>();
        public static IconsSettings IconsOpen(string path)
        {
            var json = File.ReadAllText(path);

            try
            {
                var settings = JsonSerializer.Deserialize<IconsSettings>(json);
                return settings;
            }
            catch (Exception e)
            {

            }
            return new IconsSettings();
        }

        public static void Save(IconsSettings settings, string path)
        {
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    WriteIndented = true,
                };
                var json = JsonSerializer.Serialize(settings, options);

                File.WriteAllText(path, json);
            }
            catch (Exception e)
            {
            }
        }
    }
}
