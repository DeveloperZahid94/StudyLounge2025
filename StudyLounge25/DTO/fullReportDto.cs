using StudyLounge25.DomainModels;

namespace StudyLounge25.DTO
{
    public class fullReportDto
    {
        public FeeModal Fee { get; set; }  // Full Fee details (FeeModal is the Fee entity)
        public StudentModal Student { get; set; }  // Full Student details (StudentModal is the Student entity)
        public CabinModal Cabin { get; set; }  // Full Cabin details (from CabinAssignment)
    }
}
