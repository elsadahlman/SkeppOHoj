namespace SkeppOHoj.Models
{
    public class InsuranceClaimComment
    {
        public int InsuranceClaimCommentId { get; set; }
        public int InsuranceClaimId { get; set; }   //TODO ska vara foreign key
        public InsuranceClaim InsuranceClaim { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
