using StudyLounge25.DomainModels;
using StudyLounge25.DTO;

namespace StudyLounge25.ServicesRepo.IServiceRepo
{
    public interface IFee
    {
        Task<List<FeeDto>> GetFeeDetails();
        Task<FeeModal?> CreateFeeDetails(FeeModal feeModal);
        Task<FetchFeeDetailDto> GetFeeDetailsById(Guid id);
    }
}
