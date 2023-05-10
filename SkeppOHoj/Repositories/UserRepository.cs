using Microsoft.EntityFrameworkCore;
using SkeppOHoj.Data;
using SkeppOHoj.Models;

namespace SkeppOHoj.Repositories
{
    public class UserRepository
    {

        private readonly SkeppOHojContext context;

        public UserRepository(SkeppOHojContext context)
        {
            this.context = context;
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

    }
}
