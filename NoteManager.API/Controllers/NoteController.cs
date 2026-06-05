using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NoteManager.Dtos;
using NoteManager.Services;

namespace NoteManager.Controllers;

[ApiController]
[Route("notes")]
public class NoteController : ControllerBase
{
    private readonly INoteService _service;

    public NoteController(INoteService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNote([FromBody] CreateNoteDto dto)
    {
        var createdNote = await _service.CreateNoteAsync(dto);

        return Ok(createdNote);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllNotes()
    {
        var notes = await _service.GetNotesAsync();
        return Ok(notes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNote(int id)
    {
        var note = await _service.GetSpecifiedNote(id);
        
        if (note is null)
            return NotFound();

        return Ok(note);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNote(int id, [FromBody] CreateNoteDto dto)
    {
         var updatedNote = await _service.UpdateNote(id, dto.Title,dto.Content);

        return Ok(updatedNote);
    }
}