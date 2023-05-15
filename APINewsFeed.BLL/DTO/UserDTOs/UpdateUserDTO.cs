using System.ComponentModel.DataAnnotations;

namespace APINewsFeed.BLL.DTO.UserDTOs
{
    public class UpdateUserDTO
    {
        /// <summary>
        /// id пользователя
        /// </summary>
        [Required]
        public Guid id { get; set; }
        /// <summary>
        /// имя пользователя
        /// </summary>
        public string? name { get; set; }
        /// <summary>
        /// email пользователя
        /// </summary>
        [EmailAddress]
        public string? email { get; set; }
        /// <summary>
        /// пароль пользователя
        /// </summary>
        public string? password { get; set; }
    }
}
