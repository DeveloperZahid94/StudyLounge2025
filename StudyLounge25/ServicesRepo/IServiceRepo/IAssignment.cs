using StudyLounge25.DomainModels;

namespace StudyLounge25.ServicesRepo.IServiceRepo
{
    public interface IAssignment
    {
        Task<List<CabinAssignmentModal>> GetAllAssignments();
        Task<CabinAssignmentModal?> AddAssignment(CabinAssignmentModal cabinAssignment);
        Task<CabinAssignmentModal?> UpdateAssignmnet(CabinAssignmentModal cabinAssignment, Guid id);

        Task<CabinAssignmentModal?> DeleteAssignment(Guid id);

    }
}
