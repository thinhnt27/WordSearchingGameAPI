using WordSearchingGameAPI.Models;
using WordSearchingGameAPI.Repository;

namespace WordSearchingGameAPI.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WordSearchingGameContext _context;

        public UserRepository User { get; private set; }

        public WordRepository Word { get; private set; }

        public DifficultyRepository Difficulty { get; private set; }

        public UserProgressRepository UserProgress { get; private set; }

        public LevelRepository Level { get; private set; }

        public TopicRepository Topic { get; private set; }

        public UnitOfWork(WordSearchingGameContext context)
        {
            _context = context;
            User = new UserRepository(_context);
            Word = new WordRepository(_context);
            Difficulty = new DifficultyRepository(_context);
            UserProgress = new UserProgressRepository(_context);
            Level = new LevelRepository(_context);
            Topic = new TopicRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
