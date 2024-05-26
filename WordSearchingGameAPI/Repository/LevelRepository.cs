using Microsoft.EntityFrameworkCore;
using WordSearchingGameAPI.Models;

namespace WordSearchingGameAPI.Repository
{
    public class LevelRepository : GenericRepository<Level>
    {
        public LevelRepository(WordSearchingGameContext context) : base(context)
        {

        }

        public async Task<Level?> GetLevelWithDetailsAsync(int? id)
        {
            return await _dbSet
                .Include(l => l.Topic)  // Bao gồm bảng Topic
                .Include(l => l.Difficulty)  // Bao gồm bảng Difficulty
                .FirstOrDefaultAsync(l => l.LevelId == id);
        }

        public async Task<IEnumerable<Level>> GetLevelsByTopicIdAndDifficultyIdAsync(int? topicId, int? difficultyId)
        {
            return await _dbSet
                .Where(l => l.TopicId == topicId && l.DifficultyId == difficultyId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Level>> GetLevelByUserIdAndDifficultyIdAndTopicIdAsync(int userId, int? topicId, int? difficultyId)
        {
            var userProgresses = await _context.UserProgresses
                .Where(up => up.UserId == userId)
                .ToListAsync();

            var levelIds = userProgresses.Select(up => up.LevelId.Value).Distinct();

            var levels = await _context.Levels
                .Where(l => levelIds.Contains(l.LevelId) && l.TopicId == topicId && l.DifficultyId == difficultyId)
                .ToListAsync();

            return levels;


        }

        public async Task<Level?> GetLevelByLevelNumberAndTopicNameAndDifficultyName(string topicName, string difficultyLevel, int levelNumber)
        {
            return await _dbSet
                .Include(l => l.Topic)
                .Include(l => l.Difficulty)
                .FirstOrDefaultAsync(l => l.Topic.TopicName == topicName && l.Difficulty.DifficultyLevel == difficultyLevel && l.LevelNumber == levelNumber);
        }
    }
}
