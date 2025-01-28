using Microsoft.EntityFrameworkCore;

namespace StudyLounge25.DomainModels
{
    public class AdminLogModal
    {
        public Guid LogId { get; set; }
        public int? AdminId { get; set; }
        public string Action { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
