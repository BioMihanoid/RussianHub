namespace RussianHub.Models;

public class Model
{
    public int Id { get; set; }
    public int CountVideos { get; set; }
    public int CountSubscribers { get; set; }
    public string Nationality { get; set; } = null!;
    public PersonalParameters PersonalParameters { get; set; } = null!;

}