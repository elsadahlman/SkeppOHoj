using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SkeppOHoj.Data;
using SkeppOHoj.Models;
using SkeppOHoj.Models.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.Design;
using System.Threading.Tasks;

namespace SkeppOHoj.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int userId);
        Task<List<User>> GetUsersAsync();
        Task<User> DeleteUserAsync(int userId);
        Task<User> AddUserAsync(UserCreationDto dto);
        Task<User> PutUserAsync(int id, UserCreationDto userDto);
        //Task<User> PatchUserAsync(int id, UserCreationDto userDto);
    }

    public class UserRepository : IUserRepository
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

            if (user == null)
            {
                return null;
            }

            context.User.Remove(user);
            context.SaveChanges();
            return user;
        }

        public async Task<User> AddUserAsync(UserCreationDto dto)
        {
            User user = mapper.Map<User>(dto);
            var addedUser = context.User.Add(user); 
            context.SaveChanges();
            return addedUser.Entity;    //TODO Lägg till validering, inte flera med samma personnummer 
        }

        public async Task<User> PutUserAsync(int id, UserCreationDto userDto)
        {
            var user = await context.User.FirstOrDefaultAsync(x => x.UserId == id);
            if (user == null)
            {
                return null;
            }

            user = mapper.Map<UserCreationDto, User>(userDto, user);
            context.SaveChanges();

            return user;
        }

    }
}
