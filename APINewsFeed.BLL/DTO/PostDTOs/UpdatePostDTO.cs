using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace APINewsFeed.BLL.DTO.PostDTOs
{
    public class UpdatePostDTO
    {
        /// <summary>
        /// id поста
        /// </summary>
        [Required]
        public Guid id { get; set; }
        /// <summary>
        /// заголовок поста
        /// </summary>
        public string? title { get; set; }
        /// <summary>
        /// текст поста
        /// </summary>
        public string? text { get; set; }
        /// <summary>
        /// картинка поста
        /// </summary>
        public IFormFile? image { get; set; }


    }
}
