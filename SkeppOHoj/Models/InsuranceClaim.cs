namespace SkeppOHoj.Models
{
    public class InsuranceClaim
    {
        public long InsuranceClaimId { get; set; }
        public long StatusId { get; set; }
        public DateTime Date { get; set; }
        public string? Description{ get; set; }
        public double Amount { get; set; }
    }
}
