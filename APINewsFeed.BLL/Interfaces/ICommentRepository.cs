using APINewsFeed.BLL.DTO.CommentDTOs;

namespace APINewsFeed.BLL.Interfaces
{
    public interface ICommentRepository
    {
        Task AddComment(AddCommentDTO addCommentDTO);
        Task<List<CommentDTO>> GetComments(GetCommentsDTO getCommentsDTO);
        Task<int?> DeleteComment(DeleteCommentDTO deleteCommentDTO);

    }
}
