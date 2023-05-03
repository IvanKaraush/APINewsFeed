using APINewsFeed.BLL.DTO.FavoritePostDTOs;
using APINewsFeed.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APINewsFeed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavoritesPostController : ControllerBase
    {
        private readonly IFavoritesPostRepository _favoritePostRepository;
        public FavoritesPostController(IFavoritesPostRepository favoritePostRepository)
        {
            _favoritePostRepository = favoritePostRepository;
        }

        /// <summary>
        /// Получить посты из избранного
        /// </summary>
        /// <response code="200">Возвращает список постов</response>
        /// <response code="404">Такого поста не существует</response>
        [HttpGet("get")]
        public async Task<ActionResult> GetPost([FromQuery] GetFavoritesPostsDTO getFavoritePostsDTO)
        {
            var favoritesPosts = await _favoritePostRepository.GetPosts(getFavoritePostsDTO);
            if (!favoritesPosts.Any()) return NotFound("Постов не найдено");
            return Ok(favoritesPosts);
        }

        /// <summary>
        /// Добавить пост в избранное
        /// </summary>
        /// <response code="200">Пост добавлен в избранное</response>
        /// <response code="400">Этот пост уже добавлен в избранное</response>
        [HttpPost("add")]
        public async Task<ActionResult> AddPost([FromForm] AddPostToFavoritesDTO addPostToFavoritesDTO)
        {
            var postId = await _favoritePostRepository.AddPost(addPostToFavoritesDTO);
            if(postId == Guid.Empty) return BadRequest("Этот пост уже добавлен в избранное");
            return Ok("Пост добавлен в избранное");
        }

        /// <summary>   
        /// Удалить пост из избранного
        /// </summary>
        /// <response code="200">Пост удалён</response>
        /// <response code="404">Такого поста не существует</response>
        [HttpDelete("delete")]
        public async Task<ActionResult> DeletePost([FromForm] DeletePostFromFavoritesDTO deletePostFromFavorites)
        {
            var result = await _favoritePostRepository.DeletePost(deletePostFromFavorites);
            if (result == Guid.Empty) return NotFound("Такого поста не существует");
            return Ok("Пост удалён");
        }

        
    }
}
