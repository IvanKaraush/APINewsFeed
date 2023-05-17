using APINewsFeed.BLL.Interfaces;

namespace APINewsFeed.Middleware
{
    public class GetImage
    {
        private readonly RequestDelegate _next;
        private readonly IImageService _imageService;
        public GetImage(RequestDelegate next, IImageService service)
        {
            _next = next;
            _imageService = service;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var query = context.Request.Query;
            string? fileName;
            if (!query.ContainsKey("imageId"))
            {
                await _next.Invoke(context);
                return;
            }

            if (query.ContainsKey("imageId") && !query.ContainsKey("width") && !query.ContainsKey("height"))
            {
                fileName = query["imageId"];
                await _imageService.GetImage(context, fileName);
                return;
            }
            fileName = query["imageId"];
            int width = 0;
            int height = 0;
            if (!int.TryParse(query["width"], out width) || !int.TryParse(query["height"], out height))
            {
                context.Response.ContentType = "text/plain; charset=utf-8";
                await context.Response.WriteAsync("Некорректное значение width или height");
                return;
            }
            await _imageService.ResizeImage(context, fileName, width, height);

        }
    }
}
