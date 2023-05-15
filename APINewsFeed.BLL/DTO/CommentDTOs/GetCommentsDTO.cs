using System.ComponentModel.DataAnnotations;

namespace APINewsFeed.BLL.DTO.CommentDTOs
{
    public class GetCommentsDTO
    {
        /// <summary>
        /// id поста
        /// </summary>
        [Required]
        public Guid postId { get; set; }
        /// <summary>
        /// номер страницы
        /// </summary>
        [Required]
        public int pageNumber { get; set; }
    }
}
