using Microsoft.EntityFrameworkCore;
using WordSearchingGameAPI.Models;

namespace WordSearchingGameAPI.Repository
{
    public class UserProgressRepository : GenericRepository<UserProgress>
    {
        public UserProgressRepository(WordSearchingGameContext context) : base(context)
        {
        }
        public async Task<IEnumerable<UserProgress>> GetUserProgressDetailsAsync(int userId)
        {
            return await _dbSet
                .Where(up => up.UserId == userId && up.Completed == true) // Lọc theo UserId và chỉ lấy những level đã hoàn thành
                .Include(up => up.Level) // Bao gồm bảng Level
                    .ThenInclude(l => l.Topic) // Bao gồm bảng Topic từ Level
                .Include(up => up.Level) // Bao gồm bảng Level
                    .ThenInclude(l => l.Difficulty) // Bao gồm bảng Difficulty từ Level
                .OrderBy(up => up.Level.Topic.TopicName) // Sắp xếp theo TopicName
                .ThenBy(up => up.Level.Difficulty.DifficultyLevel) // Sau đó sắp xếp theo DifficultyLevel
                .ToListAsync();
        }

        public async Task<IEnumerable<UserProgress>> GetUserProgressByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(up => up.UserId == userId)
                .ToListAsync();
        }

        public async Task<UserProgress> GetUserProgressById(int userId)
        {
            return await _dbSet
                .Where(up => up.UserId == userId)
                .FirstOrDefaultAsync();
        }

    }
}
