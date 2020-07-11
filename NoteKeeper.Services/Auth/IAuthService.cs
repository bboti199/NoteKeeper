using System;
using System.Threading.Tasks;
using NoteKeeper.DataAccess.Models;
using NoteKeeper.Infrastructure.Dto.Auth;
using NoteKeeper.Infrastructure.Utils;

namespace NoteKeeper.Services.Auth
{
    public interface IAuthService
    {
        Task<ServiceResponse<Guid>> Register(RegisterUserDto registerUserDto);
        Task<ServiceResponse<LoginResponseDto>> Login(LoginUserDto loginUserDto);
        Task<ServiceResponse<UserInfoDto>> GetUserInfo();
    }
}