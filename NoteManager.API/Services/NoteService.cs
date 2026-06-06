using Microsoft.EntityFrameworkCore;
using NoteManager.Data;
using NoteManager.Dtos.CreateNoteRequestDto;
using NoteManager.Dtos.NoteResponseDto;
using NoteManager.Models;

namespace NoteManager.Services;

public class NoteService : INoteService
{
    private readonly AppDbContext _appDbContext;

    public NoteService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<NoteDto?> CreateNoteAsync(CreateNoteDto dto, CancellationToken cancellationToken)
    {

        if (string.IsNullOrWhiteSpace(dto.Title) || string.IsNullOrWhiteSpace(dto.Content))
        {
            return null;
        }
        
        var note = new Note()
        {
            Title = dto.Title,
            Content = dto.Content
        };

        _appDbContext.Notes.Add(note);

        await _appDbContext.SaveChangesAsync(cancellationToken);

        return new NoteDto()
        {
            Id = note.Id,
            Title = note.Title,
            Content = note.Content,
            CreatedAt = note.CreatedAt
        };
    }

    public async Task<IEnumerable<NoteDto>> GetNotesAsync(CancellationToken cancellationToken)
    {
        var notes = await _appDbContext.Notes
            .Select(note => new NoteDto
            {
                Id = note.Id,
                Title = note.Title,
                Content = note.Content,
                CreatedAt = note.CreatedAt
            })
            .ToListAsync(cancellationToken);

        return notes;
    }

    public async Task<NoteDto?> GetSpecifiedNoteAsync(Guid id, CancellationToken cancellationToken)
    {
        var note = await _appDbContext.Notes.FindAsync([id], cancellationToken);
        
        if (note is null)
            return null;
        
        return new NoteDto()
        {
            Id = note.Id,
            Title = note.Title,
            Content = note.Content,
            CreatedAt = note.CreatedAt
        };
    }

    public async Task<NoteDto?> UpdateNoteAsync(Guid id, CreateNoteDto dto, CancellationToken cancellationToken)
    {
        var note = await _appDbContext.Notes.FindAsync([id], cancellationToken);
        
        if (note is null)
            return null;

        note.Title = dto.Title;

        note.Content = dto.Content;
        
        await _appDbContext.SaveChangesAsync(cancellationToken);

        return new NoteDto
        {
            Id = note.Id,
            Title = note.Title,
            Content = note.Content,
            CreatedAt = note.CreatedAt
        };
    }
    
    public async Task<bool> DeleteNoteAsync(Guid id, CancellationToken cancellationToken)
    {
        var note = await _appDbContext.Notes.FindAsync([id], cancellationToken);

        if (note == null)
        {
            return false;
        }
        
        _appDbContext.Notes.Remove(note);
        await _appDbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}