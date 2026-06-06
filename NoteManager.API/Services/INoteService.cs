using NoteManager.Dtos.CreateNoteRequestDto;
using NoteManager.Dtos.NoteResponseDto;


namespace NoteManager.Services;

public interface INoteService
{
    Task<NoteDto?> CreateNoteAsync(CreateNoteDto dto);
    Task<IEnumerable<NoteDto>> GetNotesAsync();

    Task<NoteDto?> GetSpecifiedNoteAsync(Guid id);

    Task<NoteDto?> UpdateNoteAsync(Guid id, CreateNoteDto dto);

    Task<bool> DeleteNoteAsync(Guid id);
}