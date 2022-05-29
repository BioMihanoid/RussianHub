using System;
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
        [Display(Name = "Колличество просмотров")]
        public DateTime? DateOFPublish { get; set; } = DateTime.Now;
        public int CountViews { get; set; } = 0;
        
        
        public Video()
        {
            Comments = new List<Comment>();
            bookMarks = new List<BookMark>();
        }
        public List<BookMark> bookMarks { get; set; }
        public virtual List<Comment> Comments { get; set; }
        //public string? Duration { get; set; }
        //public virtual ICollection<Comment> Comments { get; set; }
    }
}
