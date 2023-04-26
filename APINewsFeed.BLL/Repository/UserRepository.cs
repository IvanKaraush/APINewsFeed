﻿using APINewsFeed.BLL.DTO.UserDTOs;
using APINewsFeed.BLL.Interfaces;
using APINewsFeed.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APINewsFeed.BLL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        private readonly IHasher _hasher;
        public UserRepository(ApplicationContext context, IHasher hasher)
        {
            _context = context;
            _hasher = hasher;
        }

        public async Task<Guid> UserRegistration(UserRegistrationDTO userRegistrationDTO)
        {
            var checkUser = await _context.user.SingleOrDefaultAsync(u => u.name == userRegistrationDTO.name);
            if (checkUser != null) return Guid.Empty;

            var user = new User
            {
                id = Guid.NewGuid(),
                name = userRegistrationDTO.name,
                email = userRegistrationDTO.email,
                password = _hasher.GetHash(userRegistrationDTO.password)
            };
            _context.user.Add(user);
            await _context.SaveChangesAsync();
            return user.id;
        }
        
        public async Task<Guid> UserAuthorization(UserAuthorizationDTO userAuthorizationDTO)
        {
            var user = await _context.user.SingleOrDefaultAsync(u => u.name == userAuthorizationDTO.name);
            if (user == null || user.password != _hasher.GetHash(userAuthorizationDTO.password)) 
                return Guid.Empty;
            
            return user.id;
        }
        public async Task<List<UsersDTO>> GetUsers(GetUsersDTO getUsersDTO)
        {
            var query = _context.user.AsQueryable().AsNoTracking();
            query = query.Where(u => u.name.ToLower().Contains(getUsersDTO.name.ToLower()));

            query = query.Skip((getUsersDTO.pageNumber - 1) * getUsersDTO.pageSize).Take(getUsersDTO.pageSize);
            return await query.Select(userDTO => new UsersDTO
            {
                id = userDTO.id,
                name = userDTO.name,
                email = userDTO.email
            }).ToListAsync();
        }
        public async Task<UserDTO> GetUser(Guid id)
        {
            var user = await _context.user.SingleOrDefaultAsync(u => u.id == id);
            if (user == null) return null;
            return new UserDTO
            {
                name = user.name,
                email = user.email,
            };
        }
        public async Task<UpdateUserDTO> UpdateUser(UpdateUserDTO updateUserDTO)
        {
            var user = await _context.user.SingleOrDefaultAsync(i => i.id == updateUserDTO.id);
            if (user == null) return null;

            user.name = updateUserDTO.name ?? user.name;
            user.email = updateUserDTO.email ?? user.email;
            user.password = updateUserDTO.password != null ? _hasher.GetHash(updateUserDTO.password) : user.password;

            _context.user.Update(user);
            await _context.SaveChangesAsync();
            return updateUserDTO;
        }

        public async Task<Guid> DeleteUser(Guid id)
        {
            var user = await _context.user.SingleOrDefaultAsync(i => i.id == id);
            if (user == null) return Guid.Empty;

            _context.user.Remove(user);
            await _context.SaveChangesAsync();
            return user.id;
        }
    }
}
