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
        public DateTime? DataPublish { get; set; }

        public Guid VideoId { get; set; }
        public Video? Video { get; set; }
    }
}
