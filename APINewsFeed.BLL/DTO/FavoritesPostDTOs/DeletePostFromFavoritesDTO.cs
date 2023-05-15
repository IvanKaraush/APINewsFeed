﻿
using System.ComponentModel.DataAnnotations;

namespace APINewsFeed.BLL.DTO.FavoritePostDTOs
{
    public class DeletePostFromFavoritesDTO
    {
        /// <summary>
        /// id поста
        /// </summary>
        [Required]
        public Guid postId { get; set; }
        /// <summary>
        /// id пользователя
        /// id пользователя
        /// </summary>
        [Required]
        public Guid userId { get; set; }
    }
}
