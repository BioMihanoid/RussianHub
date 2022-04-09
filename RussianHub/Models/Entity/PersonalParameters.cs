namespace RussianHub.Models;

public class PersonalParameters
{
    public int Id { get; set; }
    public int Ade { get; set; }
    public double Weigh { get; set; }
    public double Height { get; set; }
    public string Nickname { get; set; } = null!;
    public string RealName { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public string Info { get; set; } = null!;
    public string EyeColor { get; set; } = null!;
    public string HairColor { get; set; } = null!;
    public string Character { get; set; } = null!;
    public string Photo { get; set; } = null!; //что-то придумать с фотографиями
    public DateTime DatefBirth { get; set; }
}