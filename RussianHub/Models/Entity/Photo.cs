using System.ComponentModel.DataAnnotations;

namespace RussianHub.Models.Entity
{
    public class Photo
    {
        public int Id { get; set; }
        [Display(Name = "Ссылка")]
        public String? Url { get; set; }
        [Display(Name = "Альтернативный текст")]
        public String? AltText { get; set; }
    }
}
