using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APINewsFeed.DAL.Models
{
    [Table("Users")]
    [Index("id", Name = "idIndex")]
    [Index("name", Name = "nameIndex")]
    public class User
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        public string name { get; set; } = "";
        [Required]
        public string email { get; set; } = "";
        [Required]
        public string password { get; set; } = "";

        public ICollection<Post>? posts { get; set; }
    }
}
