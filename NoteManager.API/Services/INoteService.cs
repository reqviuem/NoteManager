using NoteManager.Dtos;
using NoteManager.Models;

namespace NoteManager.Services;

public interface INoteService
{
    Task<NoteDto> CreateNoteAsync(CreateNoteDto dto);
    Task<IEnumerable<Note>> GetNotesAsync();

    Task<Note?> GetSpecifiedNote(int id);

    Task<NoteDto?> UpdateNote(int id, string title, string content);
}