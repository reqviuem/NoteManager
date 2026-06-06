namespace NoteManager.Dtos.NoteResponseDto;

public class NoteDto
{
    public Guid Guid { get; set; }
    public required string  Title { get; set; }
    public required string Content { get; set; }
    public DateTime CreatedAt { get; set; }
}