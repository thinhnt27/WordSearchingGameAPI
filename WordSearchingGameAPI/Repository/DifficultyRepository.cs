using WordSearchingGameAPI.Models;

namespace WordSearchingGameAPI.Repository
{
    public class DifficultyRepository : GenericRepository<Difficulty>
    {
        public DifficultyRepository(WordSearchingGameContext context) : base(context)
        {
        }
    }
}
