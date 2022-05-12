using System.ComponentModel.DataAnnotations;

namespace RussianHub.Models
{
    public class Actor
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Имя модели")]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Имя модели на английском")]
        public string? NameOnEnglish { get; set; }
        [Required]
        [Display(Name = "Ссылка на фото модели")]
        public string? LinkPhoto { get; set; }
        [Display(Name = "Дата добавления модели")]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        [Display(Name = "Колличество видео с данной моделью")]
        public int CountVideos { get; set; } = 0;
        //[Display(Name = "Страна модели")]
        //public string? Country {  get; set; }

    }
}
