using System.ComponentModel.DataAnnotations;

namespace NoteManager.Dtos.Requests;

public class CreateNoteRequestDto
{
    [Required]
    [MinLength(1)]
    public required string Title { get; set; }
    
    [Required]
    [MinLength(1)]
    public required string Content { get; set; }
}