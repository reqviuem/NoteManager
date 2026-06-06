using System.ComponentModel.DataAnnotations;

namespace NoteManager.Models;

public class Note
{
    public Guid Guid { get; set; }
    [Required]
    public required string Title { get; set; }
    [Required]
    public required string Content { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}