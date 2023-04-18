
namespace APINewsFeed.BLL.DTO.PostDTOs
{
    public class GetPostsByUserIdDTO
    {
        /// <summary>
        /// id пользователя
        /// </summary>
        public Guid userId { get; set; }
        /// <summary>
        /// Номер страницы
        /// </summary>
        public int pageNumber { get; set; }
        /// <summary>
        /// Размер страницы
        /// </summary>
        public int pageSize{ get; set; }
    }
}
