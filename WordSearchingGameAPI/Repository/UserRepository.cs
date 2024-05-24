using WordSearchingGameAPI.Models;

namespace WordSearchingGameAPI.Repository
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(WordSearchingGameContext context) : base(context)
        {
        }
    }
}
