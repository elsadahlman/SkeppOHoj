using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkeppOHoj.Models.DTOs
{
    public class InsuranceUpdateDto
    {
        [Required]
        public DateTime EndDate { get; set; }

        [Range(0, Double.MaxValue)]
        public double Premium { get; set; }
    }
}
