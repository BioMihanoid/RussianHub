using Microsoft.AspNetCore.Identity;
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
        public Guid Id { get; set; }
        public IdentityUser User { get; set; }

        [Required]
        public RoleTypes RoleType { get; set; }
    }
}
