using System.ComponentModel.DataAnnotations;

namespace RussianHub.Models
{
    public enum RoleTypes
    {
        Admin = 1,
        Moderator = 2,
    }

    public class UserRole
    {
        

        [Key,Required]
        public string Login { get; set; }

        [Required]
        public RoleTypes RoleType { get; set; }
    }
}
