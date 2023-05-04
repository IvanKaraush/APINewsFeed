

namespace APINewsFeed.BLL.DTO.CommentDTOs
{
    public class GetCommentsDTO
    {
        /// <summary>
        /// id поста
        /// </summary>
        public Guid postId { get; set; }
        /// <summary>
        /// номер страницы
        /// </summary>
        public int pageNumber { get; set; }
    }
}
