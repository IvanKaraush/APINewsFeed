using System.ComponentModel.DataAnnotations;

namespace APINewsFeed.BLL.DTO.UserDTOs
{
    public class GetUsersDTO
    {
        /// <summary>
        /// имя пользователя
        /// </summary>
        [Required]
        public string name { get; set; } = "";
        /// <summary>
        /// номер страницы
        /// </summary>
        [Required]
        public int pageNumber { get; set; }

    }
}
