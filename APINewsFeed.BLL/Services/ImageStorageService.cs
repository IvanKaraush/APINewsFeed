using APINewsFeed.BLL.Interfaces;
using Microsoft.AspNetCore.Http;

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
        public async Task GetImage(HttpContext context, string fileName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", fileName);
            if (!File.Exists(filePath))
            {
                context.Response.StatusCode = 404;
                context.Response.ContentType = "text/plain; charset=utf-8";
                await context.Response.WriteAsync("Изображение не найдено");
                return;
            }
            if (Path.GetExtension(filePath) == "jpg") context.Response.ContentType = "image/jpeg";
            if (Path.GetExtension(filePath) == "png") context.Response.ContentType = "image/png";
            byte[] imageBytes = File.ReadAllBytes(filePath);
            context.Response.StatusCode = 200;
            await context.Response.Body.WriteAsync(imageBytes, 0, imageBytes.Length);
        }
    }
}
