

namespace APINewsFeed.BLL.DTO.CommentDTOs
{
    public class AddCommentDTO
    {
        /// <summary>
        /// id пользователя
        /// </summary>
        public Guid userId { get; set; }
        /// <summary>
        /// текст комментария
        /// </summary>
        public string text { get; set; } = "";
        /// <summary>
        /// id поста
        /// </summary>
        public Guid postId { get; set; }
    }
}
