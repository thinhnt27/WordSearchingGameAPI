using AutoMapper;
using WordSearchingGameAPI.DTOs;
using WordSearchingGameAPI.DTOs.Requests;
using WordSearchingGameAPI.DTOs.Responses;
using WordSearchingGameAPI.Models;
using WordSearchingGameAPI.Repository;
using WordSearchingGameAPI.UnitOfWorks;

namespace WordSearchingGameAPI.Service
{
    public class UserProgressService
    {
        private readonly IUnitOfWork _unitOfWorks;
        private readonly IMapper _mapper;

        public UserProgressService(IUnitOfWork unitOfWorks, IMapper mapper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
        }

        //Get all user progress
        public async Task<List<UserProgress>> GetAllUserProgressAsync()
        {
            return await _unitOfWorks.UserProgress.GetAllAsync();
        }

        //Create user progress
        public async Task<UserProgressDTO?> CreateUserProgressAsync(UserProgressDTO userProgressDTO)
        {
            var user = await _unitOfWorks.UserProgress.GetUserProgressByUserIdAsync(userProgressDTO.UserId);
            if (user == null)
            {
                return null;
            }
            foreach (var up in user)
            {
                if (up.LevelId == userProgressDTO.LevelId)
                {
                    return null;
                }
            }
            //get level's request
            var levelRequest = await _unitOfWorks.Level.GetByIdAsync(userProgressDTO.LevelId);

            //get user progress from db
            var userProgressDb = await _unitOfWorks.UserProgress.GetUserProgressByUserIdAsync(userProgressDTO.UserId);

            //get List level folow userId, difficultyId, topicId
            var levels = await _unitOfWorks.Level.GetLevelByUserIdAndDifficultyIdAndTopicIdAsync(userProgressDTO.UserId, levelRequest.TopicId, levelRequest.DifficultyId);

            
            var expectedLevelNumber = levels.Count() > 0 ? levels.Max(l => l.LevelNumber) + 1 : 1;
            if(levelRequest.LevelNumber != expectedLevelNumber)
            {
                return null;
            }
            var userProgress = _mapper.Map<UserProgress>(userProgressDTO);
            await _unitOfWorks.UserProgress.AddAsync(userProgress);
            _unitOfWorks.Complete();
            return _mapper.Map<UserProgressDTO>(userProgress);

        }

        public async Task<UserProgressDTO?> CreateUserProgressV2Async(UserProgressRequest userProgressRequest)
        {
            if(userProgressRequest.TopicName == null || userProgressRequest.DifficultyLevel == null)
            {
                return null;
            }
            var levelRequest = await _unitOfWorks.Level.GetLevelByLevelNumberAndTopicNameAndDifficultyName(userProgressRequest.TopicName, userProgressRequest.DifficultyLevel, userProgressRequest.LevelNumber);

            var userProgress = new UserProgress
            {
                UserId = userProgressRequest.UserId,
                LevelId = levelRequest.LevelId,
                Completed = userProgressRequest.Completed,
                CompletionTime = userProgressRequest.CompletionTime
            };
            //foreach (var up in user)
            //{
            //    if (up.LevelId == levelRequest?.LevelId)
            //    {
            //        return null;
            //    }
            //}
            //get level's request
            //var levelRequest = await _unitOfWorks.Level.GetByIdAsync(userProgressRequest.LevelId);

            //get user progress from db
            var existedUserProgress = await _unitOfWorks.UserProgress.GetUserProgressById(userProgressRequest.UserId);
            if (existedUserProgress != null)
            {
                existedUserProgress.Completed = userProgressRequest.Completed;
                existedUserProgress.CompletionTime = userProgressRequest.CompletionTime;
                existedUserProgress.LevelId = levelRequest.LevelId;

                await _unitOfWorks.UserProgress.UpdateAsync(existedUserProgress);
                _unitOfWorks.Complete();
                return _mapper.Map<UserProgressDTO>(existedUserProgress);
            }
            //get List level folow userId, difficultyId, topicId
            //var levels = await _unitOfWorks.Level.GetLevelByUserIdAndDifficultyIdAndTopicIdAsync(userProgressRequest.UserId, levelRequest.TopicId, levelRequest.DifficultyId);

            
            //var expectedLevelNumber = levels.Count() > 0 ? levels.Max(l => l.LevelNumber) + 1 : 1;
            //if(levelRequest.LevelNumber != expectedLevelNumber)
            //{
            //    return null;
            //}
            await _unitOfWorks.UserProgress.AddAsync(userProgress);
            _unitOfWorks.Complete();
            return _mapper.Map<UserProgressDTO>(userProgress);
        }

        //Get User by Id
        public async Task<IEnumerable<UserProgressResponse>> GetUserProgressAsync(int userId)
        {
            var userProgressList = await _unitOfWorks.UserProgress.GetUserProgressDetailsAsync(userId);
            if (userProgressList != null)
            {
                var userProgressResponseList = new List<UserProgressResponse>();
                foreach (var up in userProgressList)
                {
                    
                    //var topic = level?.Topic;
                    //var difficulty = level?.Difficulty;
                    var userResponse = new UserProgressResponse
                    {
                        UserId = up.UserId,
                        TopicId = up.Level.TopicId,
                        TopicName = up.Level.Topic.TopicName,
                        DifficultyId = up.Level.DifficultyId,
                        DifficultyLevel = up.Level.Difficulty.DifficultyLevel,
                        LevelId = up.LevelId,
                        LevelNumber = up.Level.LevelNumber,
                        Completed = up.Completed,
                        CompletionTime = up.CompletionTime
                    };

                    userProgressResponseList.Add(userResponse);
                }
                var userProgressResponse = userProgressResponseList
                    .GroupBy(x => new { x.TopicName, x.DifficultyLevel })
                    .Select(g => g.OrderByDescending(x => x.LevelNumber).First())
                    .Select(x => new UserProgressResponse
                    {
                        UserId = x.UserId,
                        TopicId = x.TopicId,
                        TopicName = x.TopicName,
                        DifficultyId = x.DifficultyId,
                        DifficultyLevel = x.DifficultyLevel,
                        LevelId = x.LevelId,
                        LevelNumber = x.LevelNumber,
                        Completed = x.Completed,
                        CompletionTime = x.CompletionTime
                     }).ToList();
                return userProgressResponse;
            }
            return null;
        }
    }
}
