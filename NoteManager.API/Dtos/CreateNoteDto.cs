using System.ComponentModel.DataAnnotations;

namespace NoteManager.Dtos;

public class CreateNoteDto
{
    [Required]
    [MinLength(1)]
    public string Title { get; set; } = "";
    
    [Required]
    [MinLength(1)]
    public string Content { get; set; } = "";
}