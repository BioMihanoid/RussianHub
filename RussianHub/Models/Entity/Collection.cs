namespace RussianHub.Models;

public class Collection
{
    public int Id { get; set; }
    public List<Video> Videos { get; set; } = null!;
}