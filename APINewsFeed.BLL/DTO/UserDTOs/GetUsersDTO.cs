
namespace APINewsFeed.BLL.DTO.UserDTOs
{
    public class GetUsersDTO
    {
        /// <summary>
        /// имя пользователя
        /// </summary>
        public string name { get; set; } = "";
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
