using APINewsFeed.BLL.Configuration;
using APINewsFeed.BLL.DTO.CommentDTOs;
using APINewsFeed.BLL.Interfaces;
using APINewsFeed.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace APINewsFeed.BLL.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationContext _context;
        private readonly AppSettings _appSettings;

        public CommentRepository(ApplicationContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public async Task<List<CommentDTO>> GetComments(GetCommentsDTO getCommentsDTO)
        {
            var query = _context.comment.AsQueryable().AsNoTracking();
            query = query.Where(c => c.postId == getCommentsDTO.postId).Include(u => u.user);
            
            return await query
            .Skip((getCommentsDTO.pageNumber - 1) * _appSettings.commentPageSize)
            .Take(_appSettings.commentPageSize)
            .OrderBy(c => c.id)
            .Select(commentDTO => new CommentDTO
            {
                id = commentDTO.id,
                userName = commentDTO.user.name,
                text = commentDTO.text
            }).ToListAsync();
        }
        public async Task AddComment(AddCommentDTO addCommentDTO)
        {
            var comment = new Comment
            {
                userId = addCommentDTO.userId,
                postId = addCommentDTO.postId,
                text = addCommentDTO.text
            };
            _context.comment.Add(comment);
            await _context.SaveChangesAsync();
            
        }

        public async Task<int?> DeleteComment(DeleteCommentDTO deleteCommentDTO)
        {
            var postComment =  await _context.comment.SingleOrDefaultAsync(p => p.id == deleteCommentDTO.id && p.userId == deleteCommentDTO.userId);
            if (postComment == null) return null;

            _context.comment.Remove(postComment);
            await _context.SaveChangesAsync();
            return postComment.id;
        }
    }
}
