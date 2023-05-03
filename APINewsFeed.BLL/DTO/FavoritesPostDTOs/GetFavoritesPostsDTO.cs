

namespace APINewsFeed.BLL.DTO.FavoritePostDTOs
{
    public class GetFavoritesPostsDTO
    {
        /// <summary>
        /// id пользователя
        /// </summary>
        public Guid userId { get; set; }
        /// <summary>
        /// номер страницы
        /// </summary>
        public int pageNumber { get; set; }
        /// <summary>
        /// размер страницы
        /// </summary>
        public int pageSize { get; set; }

    }
}
