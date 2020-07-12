using System;
using System.Collections.Generic;

namespace NoteKeeper.Infrastructure.Dto.Notes
{
    public class NoteHeaderDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<string> Keywords { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}