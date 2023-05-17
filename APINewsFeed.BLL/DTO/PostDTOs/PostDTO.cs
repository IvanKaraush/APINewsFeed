
namespace APINewsFeed.BLL.DTO.PostDTOs
{
    public class PostDTO
    {
        public Guid id { get; set; }
        public string title { get; set; } = "";
        public string text { get; set; } = "";
        public string imageUrl { get; set; } = "";
        public DateTime created { get; set; }
        public DateTime updated { get; set; }

    }
}
