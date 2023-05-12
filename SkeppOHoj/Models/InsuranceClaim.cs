namespace SkeppOHoj.Models
{
    public class InsuranceClaim
    {
        public int InsuranceClaimId { get; set; }
        public int StatusId { get; set; }
        public DateTime Date { get; set; }
        public string? Description{ get; set; }
        public double Amount { get; set; }
    }
}
