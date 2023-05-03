using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SkeppOHoj.Models
{
    [Table("Insurances")]
    public class Insurance
    {
        [Key]
        public int InsuranceId { get; set; }

        public long InsuranceTypeId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Insurances")]
        public virtual User? User { get; set; }

        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public double Premium { get; set; }

    }
}
