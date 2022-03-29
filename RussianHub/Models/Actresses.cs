using System.ComponentModel.DataAnnotations;

namespace RussianHub.Models
{
    public class Actresses
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}