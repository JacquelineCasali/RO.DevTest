using System.ComponentModel.DataAnnotations;

namespace RO.DevTest.WebApi.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }  // Salvaremos o hash da senha

        [Required]
        public string Role { get; set; }  // "Admin" ou "User"
    }
}
