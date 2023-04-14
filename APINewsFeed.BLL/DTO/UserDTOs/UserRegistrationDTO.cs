
namespace APINewsFeed.BLL.DTO.UserDTOs
{
    public class UserRegistrationDTO
    {
        /// <summary>
        /// имя пользователя
        /// </summary>
        public string name { get; set; } = "";
        /// <summary>
        /// email пользователя
        /// </summary>
        public string email { get; set; } = "";
        /// <summary>
        /// пароль пользователя
        /// </summary>
        public string password { get; set; } = "";
    }
}
