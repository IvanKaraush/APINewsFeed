
using Microsoft.AspNetCore.Http;

namespace APINewsFeed.BLL.Interfaces
{
    public interface IResizeImageService
    {
        Task ResizeImage(HttpContext context, string filePath, int width, int height);
    }
}
