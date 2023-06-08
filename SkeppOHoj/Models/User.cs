using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkeppOHoj.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PersonalNumber { get; set; }
        public string? Adress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set;}

        public ICollection<Insurance> Insurances { get; set; }
    }
}
