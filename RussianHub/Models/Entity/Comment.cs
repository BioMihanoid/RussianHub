namespace RussianHub.Models;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; } = null!;
    //public Rating Rating { get; set; } = null!;
    public User User { get; set; } = null!;
    public DateTime PublicationTime { get; set; }
}