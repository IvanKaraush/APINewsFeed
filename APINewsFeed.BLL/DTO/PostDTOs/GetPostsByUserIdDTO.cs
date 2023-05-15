using System.ComponentModel.DataAnnotations;

namespace APINewsFeed.BLL.DTO.PostDTOs
{
    public class GetPostsByUserIdDTO
    {
        /// <summary>
        /// id пользователя
        /// </summary>
        [Required]
        public Guid userId { get; set; }
        /// <summary>
        /// Номер страницы
        /// </summary>
        [Required]
        public int pageNumber { get; set; }

    }
}
