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

        return CreatedAtAction(nameof(GetNote), new { id = createdNote.Id }, createdNote);
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
        var note = await _service.GetSpecifiedNoteAsync(id);

        if (note is null)
        {
            return NotFound();
        }

        return Ok(note);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNote(int id, [FromBody] CreateNoteDto dto)
    {
        var updatedNote = await _service.UpdateNoteAsync(id, dto);

        if (updatedNote == null)
        {
            return NotFound();
        }

        return Ok(updatedNote);
    }


    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteNote(int id)
    {
        var noteToDelete = await _service.DeleteNoteAsync(id);

        if (noteToDelete)
        {
            return Ok($"Note with id: {id} deleted");
        }

        return NotFound("Note not found!");
    }
}