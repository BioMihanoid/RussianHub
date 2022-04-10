namespace RussianHub.Models;

public class User
{
    public int Id { get; set; }
    public string Nickname { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public Boolean StankinTeacher { get; set; }
    public PersonalParameters PersonalParameters { get; set; } = null!;
    //public Rating SocialRating { get; set; } = null!;
    public List<Comment> Comments { get; set; } = null!;
    public DateTime TimeOnline { get; set; }
    public DateTime DateOfRegistration { get; set; }
    public List<Model> Subscribtions { get; set; } = null!;
    //public Collection Collections { get; set; } = null!;
    //public Favourites Favourites { get; set; } = null!;
}