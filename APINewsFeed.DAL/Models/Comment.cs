using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APINewsFeed.DAL.Models
{
    [Table("Comments")]
    [Index("postId", Name = "postIdIndex")]
    public class Comment
    {
        [Key]
        public int id { get; set; }
        [Required]
        public Guid postId { get; set; }
        [Required]
        public Guid userId { get; set; }
        [Required]
        public string text { get; set; } = "";

        public Post? post { get; set; }
        public User? user { get; set; }


    }
}
