using Microsoft.EntityFrameworkCore;
using StudyLounge25.Data;
using StudyLounge25.DomainModels;
using StudyLounge25.ServicesRepo.IServiceRepo;

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
            return feeModal;
        }

        public async Task<List<FeeModal>> GetFeeDetails()
        {
            var feeModaldata = await _sLdbContext.Fees.ToListAsync();
            return feeModaldata;
        }

 
    }
}
