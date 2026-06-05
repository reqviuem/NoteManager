using NoteManager.Dtos;

namespace NoteManager.Services;

public interface INoteService
{
    Task<NoteDto> CreateNoteAsync(CreateNoteDto dto);
}