using FluentValidation;
using NoteKeeper.Infrastructure.Dto.Notes;

namespace NoteKeeper.Services.Notes.Validators
{
    public class CreateNoteValidator : AbstractValidator<CreateNoteDto>
    {
        public CreateNoteValidator()
        {
            RuleFor(n => n.Title)
                .NotEmpty()
                .NotNull();

            RuleForEach(n => n.Keywords)
                .NotNull()
                .NotEmpty();
        }
    }
}