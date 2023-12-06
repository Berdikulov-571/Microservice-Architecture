using Microsoft.AspNetCore.Http;

namespace University.Service.Interfaces.File
{
    public interface IFileService
    {
        ValueTask<string> UploadImageAsync(IFormFile file);
        ValueTask<string> UploadFileAsync(IFormFile file);

        ValueTask<bool> DeleteImageAsync(string file);
        ValueTask<bool> DeletFileAsync(string file);
        
        ValueTask<byte[]> GetImageAsync(string path);
        ValueTask<byte[]> GetFileAsync(string path);
    }
}