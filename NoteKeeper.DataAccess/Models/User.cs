using System;
using System.Collections.Generic;

namespace NoteKeeper.DataAccess.Models
{
    public class User
    {
        public User()
        {
            CreatedAt = DateTime.UtcNow;
        }
        
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string AvatarUrl { get; set; }
        public ICollection<Note> Notes { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}