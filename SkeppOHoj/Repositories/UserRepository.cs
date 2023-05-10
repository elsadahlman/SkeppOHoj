using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SkeppOHoj.Data;
using SkeppOHoj.Models;
using SkeppOHoj.Models.DTOs;

namespace SkeppOHoj.Repositories
{
    public class UserRepository
    {

        private readonly SkeppOHojContext context;
        private readonly IMapper mapper;

        public UserRepository(SkeppOHojContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<User> GetUserAsync(int userId)
        {
            var user = await context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            return user;    //TODO
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var users = await context.User.ToListAsync();
            return users;
        }

        public async Task<User> DeleteUserAsync(int userId)
        {
            var user = await context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            context.User.Remove(user);
            context.SaveChanges();
            return user;    //TODO
        }

        public async Task<User> AddUserAsync(UserCreationDto dto)
        {
            User user = mapper.Map<User>(dto);
            var addedUser = context.User.Add(user); 
            context.SaveChanges();
            return addedUser.Entity;    //TODO
        }

    }
}
