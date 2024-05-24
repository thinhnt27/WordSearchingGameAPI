using AutoMapper;
using WordSearchingGameAPI.DTOs;
using WordSearchingGameAPI.Models;
using WordSearchingGameAPI.UnitOfWorks;

namespace WordSearchingGameAPI.Service
{
    public class DifficultyService
    {
        private readonly IUnitOfWork _unitOfWorks;
        private readonly IMapper _mapper;

        public DifficultyService(IUnitOfWork unitOfWorks, IMapper mapper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
        }



        //Get all difficulties
        public async Task<List<DifficultyDTO>> GetAllDifficultiesAsync()
        {
            var difficulties = await _unitOfWorks.Difficulty.GetAllAsync();
            return _mapper.Map<List<DifficultyDTO>>(difficulties);
        }
    }
}
