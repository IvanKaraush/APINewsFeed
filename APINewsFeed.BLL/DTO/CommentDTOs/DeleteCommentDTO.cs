
namespace APINewsFeed.BLL.DTO.CommentDTOs
{
    public class DeleteCommentDTO
    {
        /// <summary>
        /// id пользователя
        /// </summary>
        public Guid userId { get; set; }

        /// <summary>
        /// id комментария
        /// </summary>
        public int id { get; set; }


    }
}
