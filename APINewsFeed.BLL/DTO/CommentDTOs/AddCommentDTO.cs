using System.ComponentModel.DataAnnotations;

namespace APINewsFeed.BLL.DTO.CommentDTOs
{
    public class AddCommentDTO
    {
        /// <summary>
        /// id пользователя
        /// </summary>
        [Required]
        public Guid userId { get; set; }
        /// <summary>
        /// текст комментария
        /// </summary>
        [Required]
        public string text { get; set; } = "";
        /// <summary>
        /// id поста
        /// </summary>
        [Required]
        public Guid postId { get; set; }
    }
}
