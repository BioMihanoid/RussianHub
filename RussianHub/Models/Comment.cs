namespace RussianHub.Models;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; } = null!;
    public Rating Rating { get; set; } = null!;
}