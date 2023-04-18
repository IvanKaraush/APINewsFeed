using Microsoft.AspNetCore.Http;

namespace APINewsFeed.BLL.DTO.PostDTOs
{
    public class CreatePostDTO
    {
        /// <summary>
        /// id пользователя который создаёт пост
        /// </summary>
        public Guid userId { get; set; }
        /// <summary>
        /// заголовок поста
        /// </summary>
        public string title { get; set; } = "";
        /// <summary>
        /// текст поста
        /// </summary>
        public string text { get; set; } = "";
        /// <summary>
        /// картинка поста
        /// </summary>
        public IFormFile image { get; set; }


    }
}
