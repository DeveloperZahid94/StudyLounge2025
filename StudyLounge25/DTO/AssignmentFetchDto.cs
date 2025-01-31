using StudyLounge25.DomainModels;

namespace StudyLounge25.DTO
{
    public class AssignmentFetchDto
    {
        public Guid AssignmentId { get; set; }
        public Guid StudentId { get; set; }
        public string StudentName { get; set; }
        public Guid CabinId { get; set; }
        public string CabinName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string AssignmentStatus { get; set; }
    }
}
