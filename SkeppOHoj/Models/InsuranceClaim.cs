namespace SkeppOHoj.Models
{
    public class InsuranceClaim
    {
        public int InsuranceClaimId { get; set; }
        public int InsuranceId { get; set; }
        public Insurance Insurance { get; set; }
        public int ClaimStatusId { get; set; }
        public DateTime Date { get; set; }
        public string? Description{ get; set; }
        public double Amount { get; set; }
    }
}
