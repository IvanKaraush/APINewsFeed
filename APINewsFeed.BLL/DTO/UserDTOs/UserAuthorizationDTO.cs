using System.ComponentModel.DataAnnotations;

namespace APINewsFeed.BLL.DTO.UserDTOs
{
    public class UserAuthorizationDTO
    {
        /// <summary>
        /// имя пользователя
        /// </summary>
        [Required]
        public string name { get; set; }

        /// <summary>
        /// пароль пользователя
        /// </summary>
        [Required]
        public string password { get; set; }
    }
}
