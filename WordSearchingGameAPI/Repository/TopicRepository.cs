using WordSearchingGameAPI.Models;

namespace WordSearchingGameAPI.Repository
{
    public class TopicRepository : GenericRepository<Topic>
    {
        public TopicRepository(WordSearchingGameContext context) : base(context)
        {
        }
    }
}
