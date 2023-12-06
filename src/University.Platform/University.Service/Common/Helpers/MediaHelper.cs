using University.Domain.Exceptions.Files;

namespace University.Service.Common.Helpers
{
    public class MediaHelper
    {
        public static string MakeImageName(string filename)
        {
            FileInfo fileInfo = new FileInfo(filename);

            string[] ImageExtension = GetImageExtensions();

            if (ImageExtension.Any(x => x == fileInfo.Extension))
            {
                string extension = fileInfo.Extension;
                string name = "IMG_" + Guid.NewGuid() + extension;
                return name;
            }
            throw new ImageNotValid();
        }

        public static string MakeFileName(string filename)
        {
            FileInfo fileInfo = new FileInfo(filename);

            string[] ImageExtension = GetFileExtensions();

            if (ImageExtension.Any(x => x == fileInfo.Extension))
            {
                string extension = fileInfo.Extension;
                string name = "FILE_" + Guid.NewGuid() + extension;
                return name;
            }
            throw new FileNotValid();
        }

        public static string[] GetImageExtensions()
        {
            return new string[]
            {
            ".jpg", ".jpeg",
            ".png",
            ".bmp",
            ".svg"
            };
        }

        public static string[] GetFileExtensions()
        {
            return new string[]
            {
            ".doc",
            ".docx",
            ".xls",
            ".xlsx",
            ".pdf",
            ".txt",
            ".zip",
            ".rar",
            };
        }
    }
}