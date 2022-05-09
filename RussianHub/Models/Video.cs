using System.ComponentModel.DataAnnotations;

namespace RussianHub.Models
{
    public class Video
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Название видео")]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Ссылка на видео")]
        public string? Link { get; set; }
        [Required]
        [Display(Name = "Ссылка на превью к видео")]
        public string? LinkPreview { get; set; }
        [Display(Name = "Описание видео")]
        public string? Description { get; set; }
        [Required]
        [Display(Name = "Жанры видео")]
        public string? Genres { get; set; }
        [Display(Name = "Актеры видео")]
        public string? Actors { get; set; }
        [Display(Name = "Теги видео")]
        public string? Tags { get; set; }
    }
}
