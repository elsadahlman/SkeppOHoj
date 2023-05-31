namespace SkeppOHoj.Models
{
    public class InsuranceClaimCommentCreationDto
    {
        public int InsuranceClaimId { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
