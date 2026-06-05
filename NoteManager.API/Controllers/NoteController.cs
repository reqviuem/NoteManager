using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NoteManager.Dtos;
using NoteManager.Services;

namespace NoteManager.Controllers;

[ApiController]

public class NoteController : ControllerBase
{
    private readonly INoteService _service;

    public NoteController(INoteService service)
    {
        _service = service;
    }
    
    [HttpPost]
    [Route("/notes")]
    public async Task<IActionResult> CreateNote([FromBody] CreateNoteDto dto)
    {
        var createdNote = await _service.CreateNoteAsync(dto);

        return Ok(createdNote);
    }
}