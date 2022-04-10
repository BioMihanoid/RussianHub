using System.ComponentModel.DataAnnotations;

namespace RussianHub.Models;

public class PersonalParameters
{
    public int Id { get; set; }
    [Display(Name = "Возраст")]
    public int Ade { get; set; }
    [Display(Name = "Вес")]
    public double Weigh { get; set; }
    [Display(Name = "Рост")]
    public double Height { get; set; }
    [Display(Name = "Ник")]
    public string Nickname { get; set; } = null!;
    [Display(Name = "Имя")]
    public string RealName { get; set; } = null!;
    [Display(Name = "Город")]
    public string City { get; set; } = null!;
    [Display(Name = "Пол")]
    public string Gender { get; set; } = null!;
    [Display(Name = "Информация о себе")]
    public string Info { get; set; } = null!;
    [Display(Name = "Цвет глаз")]
    public string EyeColor { get; set; } = null!;
    [Display(Name = "Цвет волос")]
    public string HairColor { get; set; } = null!;
    [Display(Name = "Характер")]
    public string Character { get; set; } = null!;
    //что-то придумать с фотографиями
    [Display(Name = "Дата рождения")]
    public DateTime DatefBirth { get; set; }
}