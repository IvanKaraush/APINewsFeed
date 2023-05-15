using System.ComponentModel.DataAnnotations;

namespace APINewsFeed.BLL.DTO.UserDTOs
{
    public class DeleteUserDTO
    {
        /// <summary>
        /// id пользователя
        /// </summary>
        [Required]
        public Guid id { get; set; }
    }
}
