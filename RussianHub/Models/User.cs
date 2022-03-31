namespace RussianHub.Models;

public class User
{
    public int Id { get; set; }
    public string Nickname { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public Boolean StankinTeacher { get; set; }
    public PersonalParameters PersonalParameters { get; set; } = null!;
    public Rating SocialRating { get; set; } = null!;
    public Comment[] Comments { get; set; } = null!;
    //подписки пользователя (видосы + модели)
    public DateTime TimeOnline { get; set; }
    public DateTime DateOfRegistration { get; set; }
}