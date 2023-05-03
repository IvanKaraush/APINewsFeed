﻿using System.ComponentModel.DataAnnotations.Schema;

namespace APINewsFeed.DAL.Models
{
    [Table("Favorite")]
    public class FavoritePosts
    {
        public Guid userId { get; set; }
        public User? user { get; set; } 
        public Guid postId { get; set; }
        public Post? post { get; set; }

    }
}
