namespace SkeppOHoj.Models
{
    public class Insurance
    {

        public long InsuranceId { get; set; }
        
        public long InsuranceTypeId { get; set; }
        
        public int UserId { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public double Premium { get; set; }

    }
}
