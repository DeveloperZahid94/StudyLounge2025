using StudyLounge25.DomainModels;

namespace StudyLounge25.DTO
{
    public class AssignmentSaveDto
    {
        public Guid StudentId { get; set; }
        public Guid CabinId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string AssignmentStatus { get; set; }
    }
}
