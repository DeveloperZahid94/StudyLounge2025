using Microsoft.AspNetCore.Mvc;
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

        public async Task<StudentModal?> AddStudent(StudentModal studentModal)
        {
            await _sLdbContext.Students.AddAsync(studentModal);
            await _sLdbContext.SaveChangesAsync();
            return studentModal;

        }

        public async Task<List<StudentModal>> GetAll()
        {
            return await _sLdbContext.Students.ToListAsync();
        }

        public async Task<StudentModal?> UpdateStudentDetails(Guid id, StudentModal studentModal)
        {
            var recordExists = await _sLdbContext.Students.FirstOrDefaultAsync(x=>x.StudentId==id);
            if (recordExists == null)
            {
                return null;
            }
            recordExists.FirstName=studentModal.FirstName;
            recordExists.LastName=studentModal.LastName;    
            recordExists.Email=studentModal.Email;
            recordExists.Address=studentModal.Address;
            recordExists.PhoneNumber=studentModal.PhoneNumber;
            recordExists.DateOfBirth=   studentModal.DateOfBirth;
            recordExists.RegistrationDate= studentModal.RegistrationDate;
            await _sLdbContext.SaveChangesAsync();
            return studentModal;
        }

        [HttpDelete("DeleteStudent{id}")]
        public async Task<StudentModal?> DeleteStudent(Guid id)
        {
            var recordExist = await _sLdbContext.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            if (recordExist == null)
            {
                return null;
            }
            _sLdbContext.Students.Remove(recordExist);
            await _sLdbContext.SaveChangesAsync();
            return recordExist;
        }

        
    }
}
