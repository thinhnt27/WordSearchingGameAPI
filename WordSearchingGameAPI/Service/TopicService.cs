using WordSearchingGameAPI.Models;
using WordSearchingGameAPI.UnitOfWorks;

namespace WordSearchingGameAPI.Service
{
    public class TopicService
    {

        private readonly IUnitOfWork _unitOfWorks;

        public TopicService(IUnitOfWork unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        //Get all topics
        public async Task<List<Topic>> GetAllTopicsAsync()
        {
            return await _unitOfWorks.Topic.GetAllAsync();
        }
    }
}
