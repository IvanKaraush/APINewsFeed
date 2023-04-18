using APINewsFeed.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Design;

namespace APINewsFeed.BLL.Services
{
    public class ImageStorageService : IImageService
    {
        public async Task<string> SaveImage(IFormFile image)
        {
            DirectoryInfo info = new(Directory.GetCurrentDirectory() + "/Images/");
            if (!info.Exists) info.Create();

            string fileName = Guid.NewGuid() + image.FileName;
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Images", fileName);

            using (var fs = new FileStream(fullPath, FileMode.OpenOrCreate))
            {
                await image.CopyToAsync(fs);
            }
            return fileName;
        }
        public async Task<string> UpdateImage(IFormFile imageUpdate, string fileName)
        {
            DeleteImage(fileName);
            return await SaveImage(imageUpdate);
        }
        public void DeleteImage(string fileName)
        {
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Images", fileName);
            File.Delete(fullPath);
        }
    }
}
