namespace StudyLounge25.DomainModels
{
    public class CabinSpecificationModal
    {
        public Guid SpecificationId { get; set; }
        public Guid? CabinId { get; set; }
        public string SpecificationType { get; set; }
        public string Description { get; set; }

        public virtual CabinModal Cabin { get; set; }
    }
}
