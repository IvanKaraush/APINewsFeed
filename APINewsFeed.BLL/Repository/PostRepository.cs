﻿using APINewsFeed.BLL.Configuration;
using APINewsFeed.BLL.DTO.PostDTOs;
using APINewsFeed.BLL.Interfaces;
using APINewsFeed.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace APINewsFeed.BLL.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationContext _context;
        private readonly IImageService _imageService;
        private readonly AppSettings _appSettings;
        public PostRepository(ApplicationContext context, IImageService imageService, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _imageService = imageService;
            _appSettings = appSettings.Value;
        }

        public async Task<List<PostDTO>> GetPostsByUserId(GetPostsByUserIdDTO getPostsByUserIdDTO)
        {
            var query = _context.post.AsQueryable().AsNoTracking();

            query = query.Where(p => p.userId == getPostsByUserIdDTO.userId);
            query = query.Skip((getPostsByUserIdDTO.pageNumber - 1) * getPostsByUserIdDTO.pageSize).Take(getPostsByUserIdDTO.pageSize);
            return await query.Select(postDTO => new PostDTO
            {
                id = postDTO.id,
                title = postDTO.title,
                text = postDTO.text,
                imageUrl = _appSettings.URL + postDTO.image,
                created = postDTO.created
            }).ToListAsync();
        }
        public async Task<List<PostDTO>> GetPosts(FilterPostDTO filterPostDTO)
        {
            var query = _context.post.AsQueryable().AsNoTracking();

            if (!string.IsNullOrEmpty(filterPostDTO.filterBy))
            {
                query = filterPostDTO.filterBy switch
                {
                    "text" => query.Where(p => p.text.ToLower().Contains(filterPostDTO.text.ToLower())),
                    "title" => query.Where(p => p.title.ToLower().Contains(filterPostDTO.title.ToLower())),
                    _ => query
                };
            }
            var isDesc = filterPostDTO.desc ?? false;
            query = isDesc ? query.OrderByDescending(p => p.created) : query.OrderBy(p => p.created);

            query = query.Skip((filterPostDTO.pageNumber - 1) * filterPostDTO.pageSize).Take(filterPostDTO.pageSize);
            return await query.Select(postDTO => new PostDTO
            {
                id = postDTO.id,
                title = postDTO.title,
                text = postDTO.text,
                imageUrl = _appSettings.URL + postDTO.image,
                created = postDTO.created
            }).ToListAsync();
        }

        public async Task<PostDTO> GetPostById(Guid id)
        {
            var post = await _context.post.SingleOrDefaultAsync(p => p.id == id);
            if (post == null) return null;
            return new PostDTO
            {
                id = post.id,
                title = post.title,
                text = post.text,
                imageUrl = _appSettings.URL + post.image,
                created = post.created
            };
        }
        public async Task CreatePost(CreatePostDTO createPostDTO)
        {
            var post = new Post
            {
                id = Guid.NewGuid(),
                title = createPostDTO.title,
                text = createPostDTO.text,
                created = DateTime.UtcNow,
                updated = DateTime.UtcNow,
                image = await _imageService.SaveImage(createPostDTO.image),
                userId = createPostDTO.userId
            };
            _context.post.Add(post);
            await _context.SaveChangesAsync();
        }
        public async Task<UpdatePostDTO> UpdatePost(UpdatePostDTO updatePostDTO)
        {
            var post = await _context.post.SingleOrDefaultAsync(p => p.id == updatePostDTO.id);
            if (post == null) return null;

            post.title = updatePostDTO.title ?? post.title;
            post.text = updatePostDTO.text ?? post.text;
            post.image = updatePostDTO.image != null ? await _imageService.UpdateImage(updatePostDTO.image, post.image) : post.image;
            post.updated = DateTime.UtcNow;
            
            _context.post.Update(post);
            await _context.SaveChangesAsync();
            return updatePostDTO;
        }
        public async Task<Guid> DeletePost(Guid id)
        {
            var post = await _context.post.SingleOrDefaultAsync(p => p.id == id);
            if (post == null) return Guid.Empty;

            _imageService.DeleteImage(post.image);
            _context.post.Remove(post);
            await _context.SaveChangesAsync();
            return post.id;
        }
    }
}
