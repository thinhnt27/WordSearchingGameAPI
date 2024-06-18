using Microsoft.EntityFrameworkCore;
using WordSearchingGameAPI.Models;

namespace WordSearchingGameAPI.Repository
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(WordSearchingGameContext context) : base(context)
        {
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
        }
    }
}
