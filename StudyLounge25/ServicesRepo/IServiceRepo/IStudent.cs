using StudyLounge25.DomainModels;

namespace StudyLounge25.ServicesRepo.IServiceRepo
{
    public interface IStudent
    {
        Task<List<StudentModal>> GetAll();
        Task<StudentModal?> AddStudent(StudentModal studentModal);
        Task<StudentModal?> UpdateStudentDetails(Guid id, StudentModal studentModal);
        Task<StudentModal?> DeleteStudent(Guid id);

        Task<IEnumerable<StudentModal>> SearchStudent(string searchtext);
    }
}
