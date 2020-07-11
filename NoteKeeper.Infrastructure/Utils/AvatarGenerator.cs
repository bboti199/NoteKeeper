using System.Security.Cryptography;
using System.Text;
using NoteKeeper.Infrastructure.Interfaces;

namespace NoteKeeper.Infrastructure.Utils
{
    public class AvatarGenerator : IAvatarGenerator
    {
        public string GenerateAvatar(string userName)
        {
            var hasher = MD5.Create();
            var inputBytes = Encoding.UTF8.GetBytes(userName);
            var hashedBytes = hasher.ComputeHash(inputBytes);

            var builder = new StringBuilder();
            foreach (var i in hashedBytes)
            {
                builder.Append(i.ToString("X2"));
            }

            var hashString = builder.ToString();

            var avatarUrl = $"https://api.adorable.io/avatars/500/{hashString}.png";

            return avatarUrl;
        }
    }
}