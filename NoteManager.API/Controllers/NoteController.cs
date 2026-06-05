using Microsoft.AspNetCore.Mvc;
using NoteManager.Dtos;

namespace NoteManager.Controllers;

[ApiController]
public class NoteController
{
    public async Task<IActionResult> CreateNote([FromBody] CreateNoteDto dto)
    {
        
    }
}