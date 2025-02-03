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
            var student = await _sLdbContext.Students.FirstOrDefaultAsync(x => x.StudentId == cabinAssignment.StudentId);
            if (student != null)
            {
                student.Status = "Assigned";
                _sLdbContext.Students.Update(student);
                await _sLdbContext.SaveChangesAsync();
            }

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

            using var transaction = await _sLdbContext.Database.BeginTransactionAsync();
            try
            {
                var cabin = await _sLdbContext.CabinAssignments.FirstOrDefaultAsync(x => x.AssignmentId == id);
                if (cabin == null)
                {
                    return null;
                }
                var student = await _sLdbContext.Students.FirstOrDefaultAsync(x => x.StudentId == cabin.StudentId);
                if (student == null)
                {
                    return null;
                }

                // Update the student's status
                student.Status = "Assigned"; 
                _sLdbContext.Students.Update(student); 
                await _sLdbContext.SaveChangesAsync(); 
         
                cabin.StudentId = cabinAssignment.StudentId;
                cabin.CabinId = cabinAssignment.CabinId;
                cabin.StartDate = cabinAssignment.StartDate;
                cabin.EndDate = cabinAssignment.EndDate;
                cabin.AssignmentStatus = cabinAssignment.AssignmentStatus;

                _sLdbContext.CabinAssignments.Update(cabin); 
                await _sLdbContext.SaveChangesAsync();  

                // Commit the transaction
                await transaction.CommitAsync();
                return cabin;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("An error occurred while processing the request.", ex);
            }

        }

        public async Task<CabinAssignmentModal?> DeleteAssignment(Guid id)
        {
            using var transaction = await _sLdbContext.Database.BeginTransactionAsync();
            try
            {
                var cabin = await _sLdbContext.CabinAssignments.FirstOrDefaultAsync(x => x.AssignmentId == id);
                if (cabin == null)
                {
                    return null;
                }
                var student = await _sLdbContext.Students.FirstOrDefaultAsync(x => x.StudentId == cabin.StudentId);
                if (student == null)
                {
                    return null;
                }
                student.Status = "Unassigned";
                _sLdbContext.Students.Update(student); 
                await _sLdbContext.SaveChangesAsync(); 

                _sLdbContext.CabinAssignments.Remove(cabin);  
                await _sLdbContext.SaveChangesAsync();  
                await transaction.CommitAsync();
                return cabin;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("An error occurred while processing the request.", ex);
            }
        }
    }
}
