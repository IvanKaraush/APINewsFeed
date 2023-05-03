

namespace APINewsFeed.BLL.DTO.FavoritePostDTOs
{
    public class AddPostToFavoritesDTO
    {
        /// <summary>
        /// id поста
        /// </summary>
        public Guid postId { get; set; }
        /// <summary>
        /// id пользователя
        /// </summary>
        public Guid userId { get; set; }

    }
}
