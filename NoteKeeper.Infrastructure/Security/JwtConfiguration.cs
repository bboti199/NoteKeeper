namespace NoteKeeper.Infrastructure.Security
{
    public class JwtConfiguration
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public int ExpirationDays { get; set; }
    }
}