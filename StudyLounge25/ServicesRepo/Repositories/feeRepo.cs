using Microsoft.EntityFrameworkCore;
using StudyLounge25.Data;
using StudyLounge25.DomainModels;
using StudyLounge25.DTO;
using StudyLounge25.ServicesRepo.IServiceRepo;
using Microsoft.EntityFrameworkCore;

namespace StudyLounge25.ServicesRepo.Repositories
{
    public class feeRepo:IFee
    {
        private readonly SLdbContext _sLdbContext;

        public feeRepo(SLdbContext sLdbContext)
        {
            this._sLdbContext = sLdbContext;
        }

        public async Task<FeeModal?> CreateFeeDetails(FeeModal feeModal)
        {
            await _sLdbContext.AddAsync(feeModal);
            await _sLdbContext.SaveChangesAsync();

            var assignment = await _sLdbContext.CabinAssignments
                .FirstOrDefaultAsync(a => a.StudentId == feeModal.StudentId && a.AssignmentStatus != "Active");

            if (assignment != null)
            {
                assignment.AssignmentStatus = "Active";
                _sLdbContext.CabinAssignments.Update(assignment);
                await _sLdbContext.SaveChangesAsync(); 
            }

            return feeModal;
        }

        public async Task<List<FeeDto>> GetFeeDetails()
        {
            var feeModaldata = await _sLdbContext.Fees.Include(a=>a.Student).ToListAsync();
            var feeDtoList = feeModaldata.Select(fee => new FeeDto
            {
                FeeId = fee.FeeId,
                Amount = fee.Amount,
                PaymentDate = fee.PaymentDate,
                PaymentStatus = fee.PaymentStatus,
                StudentId=fee.StudentId,
                StudentName = fee.Student.FirstName,
                StudentContact = fee.Student.PhoneNumber
            }).ToList();

            return feeDtoList;
        }

        public async Task<List<fullReportDto>> GetFullDetailsById(string searchTerm)
        {
            var feeModalData = await _sLdbContext.Fees
                            .Include(f => f.Student)  // Include student details
                            .Include(f => f.Student.CabinAssignments)  // Include cabin assignments for the student
                                .ThenInclude(ca => ca.Cabin)  // Include cabin details from cabin assignments
                            .Where(f => f.Student.FirstName.Contains(searchTerm))  // Search based on FirstName (like operation)
                            .ToListAsync();

            var fullDetailDto = feeModalData.Select(fee => new fullReportDto
            {
                Fee = fee,
                Student = fee.Student,
                Cabin = fee.Student.CabinAssignments.FirstOrDefault()?.Cabin
            }).ToList();
            return fullDetailDto;
        }


        public async Task<FetchFeeDetailDto> GetFeeDetailsById(Guid id)
        {
            var feeSummary = await _sLdbContext.FeeSummaries
                .FromSqlRaw(@"
                           select 
                                s.StudentId, 
                                MAX(s.FirstName + '-' + s.LastName) as Name,
                                MAX(s.Email) as Email,
                                MAX(s.PhoneNumber) as PhoneNumber,
                                MAX(s.RegistrationDate) as RegistrationDate,
                                MAX(f.PaymentDate) as PaymentDate,
                                MAX(f.PaymentStatus) as PaymentStatus,
                                MAX(DATEDIFF(DAY, cs.StartDate, cs.EndDate) * c.PricePerDay) as TotalFee,
                                SUM(f.Amount) as FeePaid,
                                MAX(c.CabinName) as CabinName
                            from 
                            Cabins c
                            join CabinAssignments cs on cs.CabinId = c.CabinId
                            join Fees f on f.StudentId = cs.StudentId
                            join Students s on s.StudentId = cs.StudentId
                            where 
                            s.StudentId = {0}
                            group by 
                            s.StudentId", id)
                 .FirstOrDefaultAsync();


            if (feeSummary == null)
            {
                return null;
            }
            var feeDetailDto = new FetchFeeDetailDto
            {
                Name = feeSummary.Name,
                Email = feeSummary.Email,
                PhoneNumber = feeSummary.PhoneNumber,
                RegistrationDate = feeSummary.RegistrationDate,
                PaymentDate = feeSummary.PaymentDate,
                PaymentStatus = feeSummary.PaymentStatus,
                TotalFee = feeSummary.TotalFee,
                FeePaid = feeSummary.FeePaid,
                CabinName=feeSummary.CabinName
            };

            return feeDetailDto;
        }
    }
}
