using APINewsFeed.BLL.DTO.PostDTOs;

namespace APINewsFeed.BLL.Interfaces
{
    public interface IPostRepository
    {
        Task<List<PostDTO>> GetPostsByUserId(GetPostsByUserIdDTO getPostsByUserIdDTO);
        Task<List<PostDTO>> GetPosts(FilterPostDTO filterPostDTO);
        Task<PostDTO> GetPostById(Guid id);
        Task CreatePost(CreatePostDTO createPostDTO);
        Task<UpdatePostDTO> UpdatePost(UpdatePostDTO updatePostDTO);
        Task<Guid> DeletePost(Guid id);
    }
}
