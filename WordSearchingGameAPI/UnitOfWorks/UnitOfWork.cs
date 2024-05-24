using WordSearchingGameAPI.Models;
using WordSearchingGameAPI.Repository;

namespace WordSearchingGameAPI.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WordSearchingGameContext _context;

        public UserRepository User { get; private set; }

        public UnitOfWork(WordSearchingGameContext context)
        {
            _context = context;
            User = new UserRepository(_context);
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
