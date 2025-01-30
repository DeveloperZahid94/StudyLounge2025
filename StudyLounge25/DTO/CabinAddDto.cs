namespace StudyLounge25.DTO
{
    public class CabinAddDto
    {
        public string CabinName { get; set; }
        public string Description { get; set; }
        public bool? HasWifi { get; set; }
        public bool? HasAc { get; set; }
        public bool? IsAvailable { get; set; }
        public decimal? PricePerDay { get; set; }
    }
}
