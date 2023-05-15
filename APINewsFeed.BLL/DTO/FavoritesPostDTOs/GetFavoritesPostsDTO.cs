using System.ComponentModel.DataAnnotations;

namespace APINewsFeed.BLL.DTO.FavoritePostDTOs
{
    public class GetFavoritesPostsDTO
    {
        /// <summary>
        /// id пользователя
        /// </summary>
        [Required]
        public Guid userId { get; set; }
        /// <summary>
        /// номер страницы
        /// </summary>
        [Required]
        public int pageNumber { get; set; }


    }
}
