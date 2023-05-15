using System.ComponentModel.DataAnnotations;

namespace APINewsFeed.BLL.DTO.PostDTOs
{
    public class DeletePostDTO
    {
        /// <summary>
        /// id поста
        /// </summary>
        [Required]
        public Guid id { get; set; }
    }
}
