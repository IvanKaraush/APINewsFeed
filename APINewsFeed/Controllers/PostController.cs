using APINewsFeed.BLL.DTO.PostDTOs;
using APINewsFeed.BLL.DTO.UserDTOs;
using APINewsFeed.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APINewsFeed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository) => _postRepository = postRepository;

        /// <summary>
        /// Получить пост по id
        /// </summary>
        /// <response code="400">Такого поста не существует</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostDTO))]
        public async Task<ActionResult> GetPostById([FromQuery] GetPostByIdDTO getPostByIdDTO)
        {
            var post = await _postRepository.GetPostById(getPostByIdDTO.id);
            if (post == null) return BadRequest("Такого поста не существует");
            return Ok(post);
        }
        /// <summary>
        /// Получить список постов
        /// </summary>
        /// <response code="400">Постов не найдено</response>
        [HttpGet("post")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostDTO))]
        public async Task<ActionResult> GetPosts([FromQuery] FilterPostDTO filterPostDTO)
        {
            var posts = await _postRepository.GetPosts(filterPostDTO);
            if (!posts.Any()) return BadRequest("Постов не найдено");
            return Ok(posts);
        }
        /// <summary>
        /// Получить список постов определённого пользователя
        /// </summary>
        /// <response code="400">Постов не найдено</response>
        [HttpGet("user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostDTO))]
        public async Task<ActionResult> GetUserPosts([FromQuery] GetPostsByUserIdDTO getPostByUserIdDTO)
        {
            var posts = await _postRepository.GetPostsByUserId(getPostByUserIdDTO);
            if (!posts.Any()) return BadRequest("Постов не найдено");
            return Ok(posts);
        }
        /// <summary>
        /// Создать пост
        /// </summary>
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreatePostDTO))]
        public async Task<ActionResult> CreatePost([FromForm] CreatePostDTO createPostDTO)
        {
            await _postRepository.CreatePost(createPostDTO);
            return Ok(createPostDTO);
        }
        /// <summary>
        /// Обновить пост
        /// </summary>
        /// <response code="400">Такого поста не существует</response>
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdatePostDTO))]
        public async Task<ActionResult> UpdatePost([FromForm] UpdatePostDTO updatePostDTO)
        {
            var updatePost = await _postRepository.UpdatePost(updatePostDTO);
            if (updatePost == null) return BadRequest("Такого поста не существует");
            return Ok(updatePost);
        }

        /// <summary>
        /// Удалить пост
        /// </summary>
        /// <response code="200">Возвращает идентификатор удалённого поста</response>
        /// <response code="400">Пост с таким id не найден</response>
        [HttpDelete("delete")]
        public async Task<ActionResult> DeletePost([FromForm] DeletePostDTO deletePostDTO)
        {
            var id = await _postRepository.DeletePost(deletePostDTO.id);
            if (id == Guid.Empty) return BadRequest("Пост с таким id не найден");
            return Ok(new { id = id });
        }
    }
}
