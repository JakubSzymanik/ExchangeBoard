using AutoMapper;
using webapi.DTOs;
using webapi.Models;

namespace webapi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Item, ItemDTO>();
            CreateMap<Photo, PhotoDTO>();
            CreateMap<Match, MatchDTO>();
        }
    }
}
