namespace SkeppOHoj.Models
{
    public class InsuranceClaimCreationDto
    {
        public int ClaimStatusId { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public double Amount { get; set; }
    }
}
