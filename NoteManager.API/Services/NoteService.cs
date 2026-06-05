using NoteManager.Data;
using NoteManager.Dtos;
using NoteManager.Models;

namespace NoteManager.Services;

public class NoteService : INoteService
{
    private readonly AppDbContext _appDbContext;

    public NoteService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<NoteDto> CreateNoteAsync(CreateNoteDto dto)
    {
        var note = new Note()
        {
            Title = dto.Title,
            Content = dto.Content,
            CreatedAt = DateTime.UtcNow
        };

        _appDbContext.Notes.Add(note);

        await _appDbContext.SaveChangesAsync();

        return new NoteDto()
        {
            Id = note.Id,
            Title = note.Title,
            Content = note.Content,
            CreatedAt = note.CreatedAt
        };
    }
}