using Microsoft.AspNetCore.Http;
using University.Service.Common.Helpers;
using University.Service.Interfaces.File;

namespace University.Service.Service.Files
{
    public class FileService : IFileService
    {
        private readonly string MEDIA = "media";
        private readonly string IMAGES = "images";
        private readonly string FILES = "files";
        private readonly string ROOTPATH;
        public FileService()
        {
            ROOTPATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        public async ValueTask<bool> DeleteImageAsync(string file)
        {
            string path = Path.Combine(ROOTPATH, file);

            if (File.Exists(path))
            {
                await Task.Run(() =>
                {
                    File.Delete(path);
                });
                return true;
            }
            return false;
        }

        public async ValueTask<byte[]> GetImageAsync(string fileName)
        {
            string path = Path.Combine(ROOTPATH, fileName);
            byte[] imageBytes = await File.ReadAllBytesAsync(path);
            return imageBytes;
        }


        public async ValueTask<string> UploadImageAsync(IFormFile file)
        {
            string newImageName = MediaHelper.MakeImageName(file.FileName.ToLower());
            string subPath = Path.Combine(MEDIA, IMAGES, newImageName);
            string path = Path.Combine(ROOTPATH, subPath);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
                return subPath;
            }
        }

        public async ValueTask<string> UploadFileAsync(IFormFile file)
        {
            string newImageName = MediaHelper.MakeFileName(file.FileName.ToLower());
            string subPath = Path.Combine(MEDIA, FILES, newImageName);
            string path = Path.Combine(ROOTPATH, subPath);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
                return subPath;
            }
        }


        public async ValueTask<bool> DeletFileAsync(string file)
        {
            string path = Path.Combine(ROOTPATH, file);

            if (File.Exists(path))
            {
                await Task.Run(() =>
                {
                    File.Delete(path);
                });
                return true;
            }
            return false;
        }

        public async ValueTask<byte[]> GetFileAsync(string fileName)
        {
            string path = Path.Combine(ROOTPATH, fileName);
            byte[] imageBytes = await File.ReadAllBytesAsync(path);
            return imageBytes;
        }
    }
}