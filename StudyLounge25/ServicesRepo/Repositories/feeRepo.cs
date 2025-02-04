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

        public async Task<FetchFeeDetailDto> GetFeeDetailsById(Guid id)
        {
            var feeSummary = await _sLdbContext.FeeSummaries
                .FromSqlRaw(@"
                            select s.FirstName+'-'+s.LastName Name,s.Email,s.PhoneNumber,s.RegistrationDate,f.PaymentDate,f.PaymentStatus,
                            (DATEDIFF(DAY,cs.StartDate,cs.EndDate))*c.PricePerDay as TotalFee,
                            f.Amount as FeePaid,c.CabinName
                            from Cabins c join CabinAssignments cs on cs.CabinId=c.CabinId
                            join Fees f on f.StudentId=cs.StudentId
                            join Students s on s.StudentId=cs.StudentId
                            where s.StudentId={0}", id)
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
