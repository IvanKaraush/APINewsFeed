using System.ComponentModel.DataAnnotations;

namespace APINewsFeed.BLL.DTO.UserDTOs
{
    public class UserRegistrationDTO
    {
        /// <summary>
        /// имя пользователя
        /// </summary>
        [Required]
        public string name { get; set; } = "";
        /// <summary>
        /// email пользователя
        /// </summary>
        [Required]
        [EmailAddress]
        public string email { get; set; } = "";
        /// <summary>
        /// пароль пользователя
        /// </summary>
        [Required]
        public string password { get; set; } = "";
    }
}
