using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NoteKeeper.DataAccess;
using NoteKeeper.DataAccess.Models;
using NoteKeeper.Infrastructure.Dto.Notes;
using NoteKeeper.Infrastructure.Interfaces;
using NoteKeeper.Infrastructure.Utils;

namespace NoteKeeper.Services.Notes
{
    public class NoteService : INoteService
    {
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public NoteService(IUserAccessor userAccessor, IMapper mapper, ApplicationContext context)
        {
            _userAccessor = userAccessor;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<IEnumerable<NoteHeaderDto>>> GetAllNotes()
        {
            var userId = _userAccessor.GetUserIdFromContext();
            
            var notes = await _context.Notes
                .Where(n => n.UserId.ToString() == userId)
                .ToListAsync();
            
            var serviceResponse = new ServiceResponse<IEnumerable<NoteHeaderDto>>
            {
                Data = _mapper.Map<IEnumerable<NoteHeaderDto>>(notes)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<NoteDisplayDto>> GetSingleNote(string noteId)
        {
            var serviceResponse = new ServiceResponse<NoteDisplayDto>();
            
                var userId = _userAccessor.GetUserIdFromContext();

                var note = await _context.Notes
                    .SingleOrDefaultAsync(n => n.Id.ToString() == noteId && n.UserId.ToString() == userId);

                if (note == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Could not find the note";
                    return serviceResponse;
                }

                serviceResponse.Data = _mapper.Map<NoteDisplayDto>(note);

                return serviceResponse;
        }

        public async Task<ServiceResponse<NoteDisplayDto>> InsertNote(CreateNoteDto noteDto)
        {
            var userId = _userAccessor.GetUserIdFromContext();
            var serviceResponse = new ServiceResponse<NoteDisplayDto>();

            var newNote = new Note
            {
                Title = noteDto.Title,
                Content = noteDto.Content,
                Keywords = noteDto.Keywords,
                User = await _context.Users.SingleOrDefaultAsync(u => u.Id.ToString() == userId)
            };

            await _context.Notes.AddAsync(newNote);
            var result = await _context.SaveChangesAsync() > 0;

            if (!result)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Can not save note to database";
                return serviceResponse;
            }

            serviceResponse.Data = _mapper.Map<NoteDisplayDto>(newNote);

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeleteNote(string noteId)
        {
            var serviceResponse = new ServiceResponse<bool>();
            
            var userId = _userAccessor.GetUserIdFromContext();
            var note = await _context.Notes.SingleOrDefaultAsync(n => n.Id.ToString() == noteId && n.UserId.ToString() == userId);

            if (note == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Could not find the note";
                return serviceResponse;
            }

            _context.Notes.Remove(note);
            var result = await _context.SaveChangesAsync() > 0;

            if (!result)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Can not save note to database";
                return serviceResponse;
            }

            serviceResponse.Data = true;
            return serviceResponse;
        }

        public async Task<ServiceResponse<NoteDisplayDto>> UpdateNote(string noteId, UpdateNoteDto updateNoteDto)
        {
            var serviceResponse = new ServiceResponse<NoteDisplayDto>();
            var userId = _userAccessor.GetUserIdFromContext();
            var note = await _context.Notes.SingleOrDefaultAsync(n => n.Id.ToString() == noteId && n.UserId.ToString() == userId);

            if (note == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Could not find the note";
                return serviceResponse;
            }

            if (!string.IsNullOrEmpty(updateNoteDto.Title))
            {
                note.Title = updateNoteDto.Title;
            }

            if (!string.IsNullOrEmpty(updateNoteDto.Content))
            {
                note.Content = updateNoteDto.Content;
            }

            if (updateNoteDto.Keywords != null && !updateNoteDto.Keywords.SequenceEqual(note.Keywords))
            {
                note.Keywords = updateNoteDto.Keywords;
            }
            
            await _context.SaveChangesAsync();
            
            serviceResponse.Data = _mapper.Map<NoteDisplayDto>(note);

            return serviceResponse;

        }
    }
}