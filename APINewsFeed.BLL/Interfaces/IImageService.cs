using Microsoft.AspNetCore.Http;

namespace APINewsFeed.BLL.Interfaces
{
    public interface IImageService
    {
        Task<string> SaveImage(IFormFile image);
        Task<string> UpdateImage(IFormFile imageUpdate, string fileName);
        void DeleteImage(string fileName);
        Task GetImage(HttpContext context, string fileName);
        Task ResizeImage(HttpContext context, string fileName, int width, int height);
    }
}
