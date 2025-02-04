using StudyLounge25.DomainModels;

namespace StudyLounge25.DTO
{
    public class FeeDto
    {
        public Guid FeeId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentStatus { get; set; }

        // Student details in FeeDto
        public Guid? StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentContact { get; set; }

    }
}
