using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace APINewsFeed.BLL.DTO.PostDTOs
{
    public class CreatePostDTO
    {
        /// <summary>
        /// id пользователя который создаёт пост
        /// </summary>
        [Required]
        public Guid userId { get; set; }
        /// <summary>
        /// заголовок поста
        /// </summary>
        [Required]
        public string title { get; set; } = "";
        /// <summary>
        /// текст поста
        /// </summary>
        [Required]
        public string text { get; set; } = "";
        /// <summary>
        /// картинка поста
        /// </summary>
        [Required]
        public IFormFile image { get; set; }


    }
}
