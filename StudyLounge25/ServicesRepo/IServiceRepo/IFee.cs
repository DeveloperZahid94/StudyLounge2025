using StudyLounge25.DomainModels;

namespace StudyLounge25.ServicesRepo.IServiceRepo
{
    public interface IFee
    {
        Task<List<FeeModal>> GetFeeDetails();
        Task<FeeModal?> CreateFeeDetails(FeeModal feeModal);
    }
}
