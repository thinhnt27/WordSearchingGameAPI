using AutoMapper;
using WordSearchingGameAPI.DTOs;
using WordSearchingGameAPI.Models;

namespace WordSearchingGameAPI.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
//            CreateMap<Materials, MaterialsModel>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Difficulty, DifficultyDTO>().ReverseMap();
            CreateMap<UserProgress, UserProgressDTO>().ReverseMap();

        }
    }
}
