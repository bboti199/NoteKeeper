using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteKeeper.Infrastructure.Dto.Notes;
using NoteKeeper.Services.Notes;

namespace NoteKeeper.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _noteService.GetAllNotes());
        }

        [HttpGet("{noteId}")]
        public async Task<IActionResult> GetSingle(string noteId)
        {
            var result = await _noteService.GetSingleNote(noteId);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CreateNoteDto noteDto)
        {
            return Created(new Uri(Request.Path, UriKind.Relative), await _noteService.InsertNote(noteDto));
        }

        [HttpPut("{noteId}")]
        public async Task<IActionResult> Update(string noteId, [FromBody] UpdateNoteDto updateNoteDto)
        {
            var result = await _noteService.UpdateNote(noteId, updateNoteDto);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpDelete("{noteId}")]
        public async Task<IActionResult> Remove(string noteId)
        {
            var result = await _noteService.DeleteNote(noteId);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return NoContent();
        }
    }
}