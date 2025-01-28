namespace StudyLounge25.DomainModels
{
    public class CabinModal
    {
        public Guid CabinId { get; set; }
        public string CabinName { get; set; }
        public string Description { get; set; }
        public bool? HasWifi { get; set; }
        public bool? HasAc { get; set; }
        public bool? IsAvailable { get; set; }
        public decimal? PricePerDay { get; set; }

        public virtual ICollection<CabinAssignmentModal> CabinAssignments { get; set; }
        public virtual ICollection<CabinSpecificationModal> CabinSpecifications { get; set; }
    }
}
