using System;
using System.ComponentModel.DataAnnotations;

namespace RussianHub.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }


        [Required]
        [Display(Name = "Имя комментатора")]
        public string? Name { get; set; }


        [Required]
        [Display(Name = "Содержание комментария")]
        public string? Content { get; set; }


        [Display(Name = "Ссылка на фото профиля")]
        public string? LinkPhotoProfile { get; set; }


        [Display(Name = "Дата публикации")]
        public DateTime? DataPublish { get; } = DateTime.Now;

        public Guid VideoId { get; set; }
        public Video? Video { get; set; }
    }
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

    }
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
        }
        public virtual List<Comment> Comments { get; set; }
        //public string? Duration { get; set; }
        //public virtual ICollection<Comment> Comments { get; set; }
    }
}
