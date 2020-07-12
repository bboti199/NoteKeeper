using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteKeeper.Infrastructure.Dto.Notes;
using NoteKeeper.Infrastructure.Utils;

namespace NoteKeeper.Services.Notes
{
    public interface INoteService
    {
        Task<ServiceResponse<IEnumerable<NoteHeaderDto>>> GetAllNotes();
        Task<ServiceResponse<NoteDisplayDto>> GetSingleNote(string noteId);
        Task<ServiceResponse<NoteDisplayDto>> InsertNote(CreateNoteDto noteDto);
        Task<ServiceResponse<bool>> DeleteNote(string noteId);
        Task<ServiceResponse<NoteDisplayDto>> UpdateNote(string noteId, UpdateNoteDto updateNoteDto);
    }
}