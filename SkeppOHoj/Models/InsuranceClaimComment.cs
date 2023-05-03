namespace SkeppOHoj.Models
{
    public class InsuranceClaimComment
    {
        public long InsuranceClaimCommentId { get; set; }
        public long InsuranceClaimId { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
