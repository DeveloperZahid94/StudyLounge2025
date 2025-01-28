namespace StudyLounge25.DomainModels
{
    public class FeeModal
    {
        public Guid FeeId { get; set; }
        public Guid? StudentId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentStatus { get; set; }

        public virtual StudentModal Student { get; set; }
    }
}
