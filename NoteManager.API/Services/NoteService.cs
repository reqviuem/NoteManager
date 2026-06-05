using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<NoteDto>> GetNotesAsync()
    {
        var notes = await _appDbContext.Notes
            .Select(note => new NoteDto
            {
                Id = note.Id,
                Title = note.Title,
                Content = note.Content,
                CreatedAt = note.CreatedAt
            })
            .ToListAsync();

        return notes;
    }

    public async Task<NoteDto?> GetSpecifiedNoteAsync(int id)
    {
        var note = await _appDbContext.Notes.FirstOrDefaultAsync(note => note.Id == id);

        return new NoteDto()
        {
            Id = note.Id,
            Title = note.Title,
            Content = note.Content,
            CreatedAt = note.CreatedAt
        };
    }

    public async Task<NoteDto?> UpdateNoteAsync(int id, string title, string content)
    {
        var note = await _appDbContext.Notes.FirstOrDefaultAsync(note => note.Id == id);
        
        if (note is null)
            return null;

        note.Title = title;

        note.Content = content;
        
        await _appDbContext.SaveChangesAsync();

        return new NoteDto
        {
            Id = note.Id,
            Title = note.Title,
            Content = note.Content,
            CreatedAt = note.CreatedAt
        };
    }
    
    public async Task<bool> DeleteNoteAsync(int id)
    {
        var note = await _appDbContext.Notes.FirstOrDefaultAsync(note => note.Id == id);

        if (note == null)
        {
            return false;
        }
        
        _appDbContext.Notes.Remove(note);
        await _appDbContext.SaveChangesAsync();

        return true;
    }
}