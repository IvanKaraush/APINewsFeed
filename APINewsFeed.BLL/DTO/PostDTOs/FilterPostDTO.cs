﻿using System.ComponentModel.DataAnnotations;

namespace APINewsFeed.BLL.DTO.PostDTOs
{
    public class FilterPostDTO
    {
        /// <summary>
        /// Фильтровать по: title, text
        /// </summary>
        public string? filterBy { get; set; }
        /// <summary>
        /// Сортировать по (title, text, created, updated)
        /// </summary>
        public string sortBy { get; set; } = "";
        /// <summary>
        /// Если true то сортирует по убыванию (по умолчанию false)
        /// </summary>
        public bool? desc { get; set; }
        /// <summary>
        /// Текст поста
        /// </summary>
        public string text { get; set; } = "";
        /// <summary>
        /// Заголовок поста
        /// </summary>
        public string title { get; set; } = "";
        /// <summary>
        /// Номер страницы
        /// </summary>
        [Required]
        public int pageNumber { get; set; }
        
    }
}
