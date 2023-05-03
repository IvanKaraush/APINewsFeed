using APINewsFeed.BLL.DTO.FavoritePostDTOs;
using APINewsFeed.BLL.DTO.PostDTOs;

namespace APINewsFeed.BLL.Interfaces
{
    public interface IFavoritesPostRepository
    {
        Task<Guid> AddPost(AddPostToFavoritesDTO addPostToFavoritesDTO);
        Task<List<PostDTO>> GetPosts(GetFavoritesPostsDTO getFavoritePostsDTO);
        Task<Guid> DeletePost(DeletePostFromFavoritesDTO deletePostFromFavorites);
    }
}
