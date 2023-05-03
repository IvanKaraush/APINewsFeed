

namespace APINewsFeed.BLL.DTO.FavoritePostDTOs
{
    public class DeletePostFromFavoritesDTO
    {
        /// <summary>
        /// id поста
        /// </summary>
        public Guid postId { get; set; }
        /// <summary>
        /// id пользователя
        /// id пользователя
        /// </summary>
        public Guid userId { get; set; }
    }
}
