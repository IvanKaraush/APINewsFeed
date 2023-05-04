using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace APINewsFeed.DAL.Models
{
    [Table("Favorites")]
    [Index("userId", Name = "userIdIndex")]
    public class FavoritePost
    {
        public Guid userId { get; set; }
        public Guid postId { get; set; }

        public User? user { get; set; }
        public Post? post { get; set; }

    }
}
