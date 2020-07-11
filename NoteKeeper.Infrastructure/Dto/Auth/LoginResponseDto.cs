using System;

namespace NoteKeeper.Infrastructure.Dto.Auth
{
    public class LoginResponseDto
    {
        public string AccessToken { get; set; }
        public Guid Id { get; set; }
    }
}