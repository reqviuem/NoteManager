using Microsoft.EntityFrameworkCore;
using NoteManager.Data;
using NoteManager.Dtos.Requests;
using NoteManager.Dtos.Responses;
using NoteManager.Models;

namespace NoteManager.Services;

public class NoteService : INoteService
{
    private readonly AppDbContext _appDbContext;

    public NoteService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<NoteRsponseDto?> CreateNoteAsync(CreateNoteRequestDto requestDto, CancellationToken cancellationToken)
    {

        if (string.IsNullOrWhiteSpace(requestDto.Title) || string.IsNullOrWhiteSpace(requestDto.Content))
        {
            return null;
        }
        
        var note = new Note()
        {
            Title = requestDto.Title,
            Content = requestDto.Content
        };

        _appDbContext.Notes.Add(note);

        await _appDbContext.SaveChangesAsync(cancellationToken);

        return new NoteRsponseDto()
        {
            Id = note.Id,
            Title = note.Title,
            Content = note.Content,
            CreatedAt = note.CreatedAt
        };
    }

    public async Task<IEnumerable<NoteRsponseDto>> GetNotesAsync(CancellationToken cancellationToken)
    {
        var notes = await _appDbContext.Notes
            .Select(note => new NoteRsponseDto
            {
                Id = note.Id,
                Title = note.Title,
                Content = note.Content,
                CreatedAt = note.CreatedAt
            })
            .ToListAsync(cancellationToken);

        return notes;
    }

    public async Task<NoteRsponseDto?> GetSpecifiedNoteAsync(Guid id, CancellationToken cancellationToken)
    {
        var note = await _appDbContext.Notes.FindAsync([id], cancellationToken);
        
        if (note is null)
            return null;
        
        return new NoteRsponseDto()
        {
            Id = note.Id,
            Title = note.Title,
            Content = note.Content,
            CreatedAt = note.CreatedAt
        };
    }

    public async Task<NoteRsponseDto?> UpdateNoteAsync(Guid id, CreateNoteRequestDto requestDto, CancellationToken cancellationToken)
    {
        var note = await _appDbContext.Notes.FindAsync([id], cancellationToken);
        
        if (note is null)
            return null;

        note.Title = requestDto.Title;

        note.Content = requestDto.Content;
        
        await _appDbContext.SaveChangesAsync(cancellationToken);

        return new NoteRsponseDto
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