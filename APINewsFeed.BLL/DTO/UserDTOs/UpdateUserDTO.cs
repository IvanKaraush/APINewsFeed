
namespace APINewsFeed.BLL.DTO.UserDTOs
{
    public class UpdateUserDTO
    {
        /// <summary>
        /// id пользователя
        /// </summary>
        public Guid id { get; set; }
        /// <summary>
        /// имя пользователя
        /// </summary>
        public string? name { get; set; }
        /// <summary>
        /// email пользователя
        /// </summary>
        public string? email { get; set; }
        /// <summary>
        /// пароль пользователя
        /// </summary>
        public string? password { get; set; }
    }
}
