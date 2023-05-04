using APINewsFeed.BLL.DTO.CommentDTOs;
using APINewsFeed.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APINewsFeed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        /// <summary>
        /// Получить коментарии поста
        /// </summary>
        /// <response code="200">Возвращает список комментариев</response>
        /// <response code="404">Комментарии не найдены</response>
        [HttpGet("comments")]
        public async Task<ActionResult> GetComments([FromQuery] GetCommentsDTO getCommentsDTO)
        {
            var comments = await _commentRepository.GetComments(getCommentsDTO);
            if (!comments.Any()) return NotFound("Комментарии не найдены");
            return Ok(comments);
        }

        /// <summary>
        /// Добавить комментарий
        /// </summary>
        /// <response code="200">Комментарий добавлен</response>
        [HttpPost("add")]
        public async Task<ActionResult> AddComment([FromForm] AddCommentDTO addCommentDTO)
        {
            await _commentRepository.AddComment(addCommentDTO);
            return Ok();
        }

        /// <summary>
        /// Удалить комментарий
        /// </summary>
        /// <response code="200">Комментарий удалён</response>
        /// <response code="404">Вы не можете удалить чужой комментарий</response>
        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteComment([FromForm] DeleteCommentDTO deleteCommentDTO)
        {
            var commentId = await _commentRepository.DeleteComment(deleteCommentDTO);
            if (commentId == null) return BadRequest("Вы не можете удалить чужой комментарий");
            return Ok(commentId);
        }
    }
}
