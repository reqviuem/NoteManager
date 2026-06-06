using Microsoft.AspNetCore.Mvc;
using NoteManager.Dtos.Requests;
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
    public async Task<IActionResult> CreateNote([FromBody] CreateNoteRequestDto requestDto, CancellationToken cancellationToken)
    {
        var createdNote = await _service.CreateNoteAsync(requestDto, cancellationToken);

        if (createdNote == null)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetNote), new { id = createdNote.Id }, createdNote);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllNotes(CancellationToken cancellationToken)
    {
        var notes = await _service.GetNotesAsync(cancellationToken);

        return Ok(notes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNote(Guid id, CancellationToken cancellationToken)
    {
        var note = await _service.GetSpecifiedNoteAsync(id, cancellationToken);

        if (note is null)
        {
            return NotFound();
        }

        return Ok(note);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNote(Guid id, [FromBody] CreateNoteRequestDto requestDto, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(requestDto.Title) || string.IsNullOrWhiteSpace(requestDto.Content))
        {
            return BadRequest();
        }
        
        var updatedNote = await _service.UpdateNoteAsync(id, requestDto, cancellationToken);
        
        if (updatedNote == null)
        {
            return NotFound();
        }

        return Ok(updatedNote);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNote(Guid id,CancellationToken cancellationToken)
    {
        var noteToDelete = await _service.DeleteNoteAsync(id, cancellationToken);

        if (noteToDelete)
        {
            return Ok(id);
        }

        return NotFound();
    }
}