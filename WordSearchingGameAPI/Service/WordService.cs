using AutoMapper;
using WordSearchingGameAPI.DTOs;
using WordSearchingGameAPI.Repository;
using WordSearchingGameAPI.UnitOfWorks;

namespace WordSearchingGameAPI.Service
{
    public class WordService
    {
        private readonly IUnitOfWork _unitOfWorks;
        private readonly IMapper _mapper;

        public WordService(IUnitOfWork unitOfWorks, IMapper mapper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
        }


        //Get words by topicId and difficultyId
        public async Task<List<WordDTO>> GetWordsByTopicIdAndDifficultyIdAsync(int topicId, int difficultyId)
        {
            return await _unitOfWorks.Word.GetWordsByTopicIdAndDifficultyIdAsync(topicId, difficultyId);
        }
    }
}
