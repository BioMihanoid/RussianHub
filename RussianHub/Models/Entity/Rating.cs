namespace RussianHub.Models;

public class Rating
{
    public int Id { get; set; }
    public int AverageRating { get; set; }
    public int CountLikes { get; set; }
    public int CountDislikes { get; set; }
}