using NoteManager.Dtos.CreateNoteRequestDto;
using NoteManager.Dtos.NoteResponseDto;


namespace NoteManager.Services;

public interface INoteService
{
    Task<NoteDto?> CreateNoteAsync(CreateNoteDto dto,CancellationToken cancellationToken);
    Task<IEnumerable<NoteDto>> GetNotesAsync(CancellationToken cancellationToken);

    Task<NoteDto?> GetSpecifiedNoteAsync(Guid id,CancellationToken cancellationToken);

    Task<NoteDto?> UpdateNoteAsync(Guid id, CreateNoteDto dto,CancellationToken cancellationToken);

    Task<bool> DeleteNoteAsync(Guid id,CancellationToken cancellationToken);
}