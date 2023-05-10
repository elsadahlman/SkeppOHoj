using System.ComponentModel.DataAnnotations;

namespace SkeppOHoj.Models.DTOs
{
    public class UserCreationDto
    {
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? PersonalNumber { get; set; }
        public string? Adress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
    }
}
