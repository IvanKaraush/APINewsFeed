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
            string? fileName = context.Request.Query["ImageId"];
            
            if (fileName == null)
            {
                await _next.Invoke(context);
                return;
            }
            await _imageService.GetImage(context, fileName);

        }
    }
}
