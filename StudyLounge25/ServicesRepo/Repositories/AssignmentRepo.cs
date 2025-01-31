using Microsoft.EntityFrameworkCore;
using StudyLounge25.Data;
using StudyLounge25.DomainModels;
using StudyLounge25.ServicesRepo.IServiceRepo;

namespace StudyLounge25.ServicesRepo.Repositories
{
    public class AssignmentRepo:IAssignment
    {
        private readonly SLdbContext _sLdbContext;

        public AssignmentRepo(SLdbContext sLdbContext)
        {
            this._sLdbContext = sLdbContext;
        }
        public async Task<CabinAssignmentModal?> AddAssignment(CabinAssignmentModal cabinAssignment)
        {
            await _sLdbContext.CabinAssignments.AddAsync(cabinAssignment);
            await _sLdbContext.SaveChangesAsync();
            return cabinAssignment;
        }

        public async Task<List<CabinAssignmentModal>> GetAllAssignments()
        {
            var assignments = await _sLdbContext.CabinAssignments
             .Include(a => a.Student)  
             .Include(a => a.Cabin)    
             .ToListAsync();
            return assignments;


        }


        public async Task<CabinAssignmentModal?> UpdateAssignmnet(CabinAssignmentModal cabinAssignment, Guid id)
        {
            var cabin = await _sLdbContext.CabinAssignments.FirstOrDefaultAsync(x => x.AssignmentId == id);
            if (cabin == null)
            {
                return null;
            }
            cabin.StudentId = cabinAssignment.StudentId;
            cabin.CabinId = cabinAssignment.CabinId;
            cabin.StartDate = cabinAssignment.StartDate;
            cabin.EndDate = cabinAssignment.EndDate;
            cabin.AssignmentStatus = cabinAssignment.AssignmentStatus;
            await _sLdbContext.SaveChangesAsync();
            return cabin;
        }

        public async Task<CabinAssignmentModal?> DeleteAssignment(Guid id)
        {
            var cabin = await _sLdbContext.CabinAssignments.FirstOrDefaultAsync(x => x.AssignmentId == id);
            if (cabin == null)
            {
                return null;
            }

            _sLdbContext.Remove(cabin);
            await _sLdbContext.SaveChangesAsync();
            return cabin;
        }
    }
}
