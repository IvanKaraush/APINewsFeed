using APINewsFeed.BLL.Configuration;
using APINewsFeed.BLL.DTO.FavoritePostDTOs;
using APINewsFeed.BLL.DTO.PostDTOs;
using APINewsFeed.BLL.Interfaces;
using APINewsFeed.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace APINewsFeed.BLL.Repository
{
    public class FavoritesPostRepository : IFavoritesPostRepository
    {
        private readonly ApplicationContext _context;
        private readonly AppSettings _appSettings;

        public FavoritesPostRepository(ApplicationContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public async Task<Guid> AddPost(AddPostToFavoritesDTO addPostDTO)
        {
            var favoritesPost = await _context.favoritePost.SingleOrDefaultAsync(u => u.userId == addPostDTO.userId && u.postId == addPostDTO.postId);
            if(favoritesPost != null) return Guid.Empty;

            var favoritePost = new FavoritePost
            {
                userId = addPostDTO.userId,
                postId = addPostDTO.postId
            };
            _context.favoritePost.Add(favoritePost);
            await _context.SaveChangesAsync();
            
            return favoritePost.postId;
        }

        public async Task<Guid> DeletePost(DeletePostFromFavoritesDTO deletePostFromFavorites)
        {
            var post = await _context.favoritePost.FirstOrDefaultAsync(p => p.userId == deletePostFromFavorites.userId && p.postId == deletePostFromFavorites.postId);
            if (post == null) return Guid.Empty;

            _context.favoritePost.Remove(post);
            await _context.SaveChangesAsync();
            return post.postId;
        }

        public async Task<List<PostDTO>> GetPosts(GetFavoritesPostsDTO getFavoritePostsDTO)
        {
            var query = _context.favoritePost.AsQueryable().AsNoTracking();

            query = query.Where(u => u.userId == getFavoritePostsDTO.userId).Include(p => p.post);
            query = query.Skip((getFavoritePostsDTO.pageNumber - 1) * getFavoritePostsDTO.pageSize).Take(getFavoritePostsDTO.pageSize);
            
            return await query.Select(postDTO => new PostDTO
            {
                id = postDTO.post.id,
                title = postDTO.post.title,
                imageUrl = _appSettings.URL + postDTO.post.image,
                text = postDTO.post.text,
                created = postDTO.post.created
            }).ToListAsync();
        }
    }
}
