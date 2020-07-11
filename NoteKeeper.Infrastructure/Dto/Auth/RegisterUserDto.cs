namespace NoteKeeper.Infrastructure.Dto.Auth
{
    public class RegisterUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}