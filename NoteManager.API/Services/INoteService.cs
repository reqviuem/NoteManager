using NoteManager.Dtos;
using NoteManager.Models;

namespace NoteManager.Services;

public interface INoteService
{
    Task<NoteDto> CreateNoteAsync(CreateNoteDto dto);
    Task<IEnumerable<NoteDto>> GetNotesAsync();

    Task<NoteDto?> GetSpecifiedNoteAsync(int id);

    Task<NoteDto?> UpdateNoteAsync(int id, CreateNoteDto dto);

    Task<bool> DeleteNoteAsync(int id);
}