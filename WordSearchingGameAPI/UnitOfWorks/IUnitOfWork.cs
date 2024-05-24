using WordSearchingGameAPI.Repository;

namespace WordSearchingGameAPI.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        UserRepository User { get; }
        int Complete();
    }
}
