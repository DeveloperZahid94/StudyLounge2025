namespace StudyLounge25.DomainModels
{
    public class CabinAssignmentModal
    {
        public Guid AssignmentId { get; set; }
        public Guid? StudentId { get; set; }
        public Guid? CabinId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string AssignmentStatus { get; set; }

        public virtual CabinModal Cabin { get; set; }
        public virtual StudentModal Student { get; set; }
    }
}
