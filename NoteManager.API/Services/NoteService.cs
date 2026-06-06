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

    public async Task<NoteDto?> CreateNoteAsync(CreateNoteDto dto)
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

        await _appDbContext.SaveChangesAsync();

        return new NoteDto()
        {
            Guid = note.Guid,
            Title = note.Title,
            Content = note.Content
        };
    }

    public async Task<IEnumerable<NoteDto>> GetNotesAsync()
    {
        var notes = await _appDbContext.Notes
            .Select(note => new NoteDto
            {
                Guid = note.Guid,
                Title = note.Title,
                Content = note.Content
            })
            .ToListAsync();

        return notes;
    }

    public async Task<NoteDto?> GetSpecifiedNoteAsync(Guid id)
    {
        var note = await _appDbContext.Notes.FirstOrDefaultAsync(note => note.Guid == id);
        
        if (note is null)
            return null;
        
        return new NoteDto()
        {
            Guid = note.Guid,
            Title = note.Title,
            Content = note.Content
        };
    }

    public async Task<NoteDto?> UpdateNoteAsync(Guid id, CreateNoteDto dto)
    {
        var note = await _appDbContext.Notes.FirstOrDefaultAsync(note => note.Guid == id);
        
        if (note is null)
            return null;

        note.Title = dto.Title;

        note.Content = dto.Content;
        
        await _appDbContext.SaveChangesAsync();

        return new NoteDto
        {
            Guid = note.Guid,
            Title = note.Title,
            Content = note.Content
        };
    }
    
    public async Task<bool> DeleteNoteAsync(Guid id)
    {
        var note = await _appDbContext.Notes.FirstOrDefaultAsync(note => note.Guid == id);

        if (note == null)
        {
            return false;
        }
        
        _appDbContext.Notes.Remove(note);
        await _appDbContext.SaveChangesAsync();

        return true;
    }
}