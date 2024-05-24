using WordSearchingGameAPI.Repository;

namespace WordSearchingGameAPI.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        UserRepository User { get; }

        WordRepository Word { get; }

        DifficultyRepository Difficulty { get; }

        UserProgressRepository UserProgress { get; }

        LevelRepository Level { get; }

        TopicRepository Topic { get; }
        int Complete();
    }
}
