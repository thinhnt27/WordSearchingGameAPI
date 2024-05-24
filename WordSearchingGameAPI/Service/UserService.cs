using AutoMapper;
using WordSearchingGameAPI.DTOs;
using WordSearchingGameAPI.Models;
using WordSearchingGameAPI.UnitOfWorks;

namespace WordSearchingGameAPI.Service
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Create User
        public async Task<UserDTO?> CreateUserAsync(UserDTO userRequest)
        {
            if(userRequest == null)
            {
                return null;
            }
            if(userRequest.PasswordHash == null)
            {
                userRequest.PasswordHash = "PasswordVerySecure";
            }
            var user = _mapper.Map<User>(userRequest);
            var userEntity = await _unitOfWork.User.AddAsync(user);
            var result = _unitOfWork.Complete();
            if(result > 0)
            {
                return _mapper.Map<UserDTO>(userEntity);
            }
            else return null;
        }
        //Get All Users
        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.User.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        //Get User By Id
        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
            var user = await _unitOfWork.User.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }
    }
}
