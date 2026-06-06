namespace NoteManager.Dtos.Responses;

public class NoteRsponseDto
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public DateTime CreatedAt { get; set; }
}