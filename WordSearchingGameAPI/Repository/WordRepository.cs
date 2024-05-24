using Microsoft.EntityFrameworkCore;
using WordSearchingGameAPI.DTOs;
using WordSearchingGameAPI.Models;

namespace WordSearchingGameAPI.Repository
{
    public class WordRepository : GenericRepository<Word>
    {
        public WordRepository(WordSearchingGameContext context) : base(context)
        {
        }
        public async Task<List<WordDTO>> GetWordsByTopicIdAndDifficultyIdAsync(int topicId, int difficultyId)
        {
            return await _context.Words
                .Where(w => w.TopicId == topicId && w.DifficultyId == difficultyId)
                .Select(w => new WordDTO
                {
                    Word = w.Word1
                })
                .ToListAsync();
        }
    }
}
