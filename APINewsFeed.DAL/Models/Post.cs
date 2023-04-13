using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APINewsFeed.DAL.Models
{
    [Table("Posts")]
    [Index("title", Name = "titleIndex")]
    [Index("created", Name = "createdIndex")]
    public class Post
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        public string title { get; set; } = "";
        [Required]
        public string description { get; set; } = "";
        [Required]
        public string image { get; set; } = "";
        [Required]
        public DateTime created { get; set; }
        [Required]
        public DateTime updated { get; set; }

        [Required]
        public Guid userId { get; set; }
        public User? user { get; set; }
    }
}
