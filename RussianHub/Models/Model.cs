using System.ComponentModel.DataAnnotations;

namespace RussianHub.Models
{
    public class Model
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Имя модели")]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Ссылка на фото модели")]
        public string? LinkPhoto { get; set; }
        [Display(Name = "Дата добавления модели")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Колличество видео с данной моделью")]
        public int CountVideos { get; set; }
        [Display(Name = "Страна модели")]
        public string? Country { get; set; }

    }
}
