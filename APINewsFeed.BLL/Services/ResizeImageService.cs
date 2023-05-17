using APINewsFeed.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;

namespace APINewsFeed.BLL.Services
{
    public class ResizeImageService : IResizeImageService
    {
        public async Task ResizeImage(HttpContext context, string filePath, int width, int height)
        {
            using (var image = Image.Load(filePath))
            {
                image.Mutate(x => x.Resize(new ResizeOptions
                {
                    Size = new Size(width, height),
                    Mode = ResizeMode.Max
                }));

                using (var outputStream = new MemoryStream())
                {
                    if (Path.GetExtension(filePath) == ".jpg")
                    {
                        image.Save(outputStream, new JpegEncoder());

                        context.Response.ContentType = "image/jpeg";
                    }
                    if(Path.GetExtension(filePath) == ".png")
                    {
                        image.Save(outputStream, new PngEncoder());

                        context.Response.ContentType = "image/png";
                    }
                    context.Response.ContentLength = outputStream.Length;

                    outputStream.Seek(0, SeekOrigin.Begin);

                    if (context.Response.HasStarted)
                        return;

                    context.Response.StatusCode = 200;
                    await outputStream.CopyToAsync(context.Response.Body);
                }
            }
        }
    }
}
