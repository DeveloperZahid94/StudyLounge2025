using StudyLounge25.DomainModels;

namespace StudyLounge25.ServicesRepo.IServiceRepo
{
    public interface IStudent
    {
        Task<List<StudentModal>> GetAll();
    }
}
