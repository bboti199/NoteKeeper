using System;
using System.Collections.Generic;

namespace NoteKeeper.DataAccess.Models
{
    public class Note
    {
        public Note()
        {
            CreatedAt = DateTime.UtcNow;
        }
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Keywords { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}