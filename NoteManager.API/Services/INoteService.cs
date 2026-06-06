using NoteManager.Dtos.Requests;
using NoteManager.Dtos.Responses;


namespace NoteManager.Services;

public interface INoteService
{
    Task<NoteRsponseDto?> CreateNoteAsync(CreateNoteRequestDto requestDto, CancellationToken cancellationToken);
    Task<IEnumerable<NoteRsponseDto>> GetNotesAsync(CancellationToken cancellationToken);
    Task<NoteRsponseDto?> GetSpecifiedNoteAsync(Guid id, CancellationToken cancellationToken);

    Task<NoteRsponseDto?> UpdateNoteAsync(Guid id, CreateNoteRequestDto requestDto,
        CancellationToken cancellationToken);

    Task<bool> DeleteNoteAsync(Guid id, CancellationToken cancellationToken);
}