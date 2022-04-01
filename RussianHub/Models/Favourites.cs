namespace RussianHub.Models;

public class Favourites
{
    public int Id { get; set; }
    public List<Video> Videos { get; set; } = null!;
}