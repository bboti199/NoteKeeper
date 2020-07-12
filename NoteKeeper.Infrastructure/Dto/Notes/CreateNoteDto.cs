using System.Collections.Generic;

namespace NoteKeeper.Infrastructure.Dto.Notes
{
    public class CreateNoteDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Keywords { get; set; }
    }
}