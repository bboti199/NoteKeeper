using AutoMapper;
using NoteKeeper.DataAccess.Models;
using NoteKeeper.Infrastructure.Dto.Auth;

namespace NoteKeeper.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterUserDto, User>();
            CreateMap<LoginUserDto, User>();

            CreateMap<User, UserInfoDto>();
            
        }
    }
}