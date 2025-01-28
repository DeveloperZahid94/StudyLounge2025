using Microsoft.EntityFrameworkCore;
using StudyLounge25.Data;
using StudyLounge25.DomainModels;
using StudyLounge25.ServicesRepo.IServiceRepo;

namespace StudyLounge25.ServicesRepo.Repositories
{
    public class StudentRepo : IStudent
    {
        private readonly SLdbContext _sLdbContext;

        public StudentRepo(SLdbContext sLdbContext)
        {
            this._sLdbContext = sLdbContext;
        }
        public async Task<List<StudentModal>> GetAll()
        {
            return await _sLdbContext.Students.ToListAsync();
        }
    }
}
