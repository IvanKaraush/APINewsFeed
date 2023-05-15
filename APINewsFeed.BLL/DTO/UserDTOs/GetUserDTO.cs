using System.ComponentModel.DataAnnotations;

namespace APINewsFeed.BLL.DTO.UserDTOs
{
    public class GetUserDTO
    {
        /// <summary>
        /// id пользователя
        /// </summary>
        [Required]
        public Guid id { get; set; }
    }
}
