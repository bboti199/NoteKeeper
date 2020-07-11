using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NoteKeeper.DataAccess;
using NoteKeeper.DataAccess.Models;
using NoteKeeper.Infrastructure.Dto.Auth;
using NoteKeeper.Infrastructure.Interfaces;
using NoteKeeper.Infrastructure.Utils;

namespace NoteKeeper.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IAvatarGenerator _avatarGenerator;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IUserAccessor _userAccessor;

        public AuthService(ApplicationContext context, IMapper mapper, IAvatarGenerator avatarGenerator,
            IJwtGenerator jwtGenerator, IUserAccessor userAccessor)
        {
            _context = context;
            _mapper = mapper;
            _avatarGenerator = avatarGenerator;
            _jwtGenerator = jwtGenerator;
            _userAccessor = userAccessor;
        }
        
        public async Task<ServiceResponse<Guid>> Register(RegisterUserDto registerUserDto)
        {
            var serviceResponse = new ServiceResponse<Guid>();
            
            if (await _context.Users.Where(u => u.Email == registerUserDto.Email).AnyAsync())
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Email address already in use";
                return serviceResponse;
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerUserDto.Password);

            var user = new User
            {
                Email = registerUserDto.Email,
                UserName = registerUserDto.UserName,
                PasswordHash = passwordHash,
                AvatarUrl = _avatarGenerator.GenerateAvatar(registerUserDto.UserName)
            };

            await _context.Users.AddAsync(user);
            var result = await _context.SaveChangesAsync() > 0;

            if (!result)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Can not save user to database";
            }

            serviceResponse.Data = user.Id;

            return serviceResponse;
        }

        public async Task<ServiceResponse<LoginResponseDto>> Login(LoginUserDto loginUserDto)
        {
            var serviceResponse = new ServiceResponse<LoginResponseDto>();

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == loginUserDto.Email);

            if (user == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Invalid Credentials";
                return serviceResponse;
            }

            var validPassword = BCrypt.Net.BCrypt.Verify(loginUserDto.Password, user.PasswordHash);
            if (!validPassword)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Invalid Credentials";
                return serviceResponse;
            }

            var token = _jwtGenerator.GenerateToken(user);
            var response = new LoginResponseDto
            {
                Id = user.Id,
                AccessToken = token
            };

            serviceResponse.Data = response;

            return serviceResponse;
        }

        public async Task<ServiceResponse<UserInfoDto>> GetUserInfo()
        {
            var serviceResponse = new ServiceResponse<UserInfoDto>();
            
            var user = await _context.Users.SingleOrDefaultAsync(u =>
                u.Id.ToString() == _userAccessor.GetUserIdFromContext());

            if (user == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "An unexpected error occured.";
                return serviceResponse;
            }

            var userInfo = _mapper.Map<UserInfoDto>(user);

            serviceResponse.Data = userInfo;
            return serviceResponse;
        }
    }
}