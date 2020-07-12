using AutoMapper;
using NoteKeeper.DataAccess.Models;
using NoteKeeper.Infrastructure.Dto.Auth;
using NoteKeeper.Infrastructure.Dto.Notes;

namespace NoteKeeper.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterUserDto, User>();
            CreateMap<LoginUserDto, User>();

            CreateMap<User, UserInfoDto>();

            CreateMap<Note, NoteDisplayDto>();
            CreateMap<Note, NoteHeaderDto>();

        }
    }
}