using NoteKeeper.DataAccess.Models;

namespace NoteKeeper.Infrastructure.Interfaces
{
    public interface IJwtGenerator
    {
        string GenerateToken(User user);
    }
}