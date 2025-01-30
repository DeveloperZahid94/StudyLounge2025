using Microsoft.AspNetCore.Mvc;
using StudyLounge25.DomainModels;
using StudyLounge25.DTO;

namespace StudyLounge25.ServicesRepo.IServiceRepo
{
    public interface ICabin
    {
        Task<List<CabinModal>> GetAllCabins();
        Task <CabinModal?> GetCabinById(Guid id);
        Task<CabinModal?> AddCabin(CabinModal cabinModal);

        Task<CabinModal?> UpdateCabin(CabinModal cabinModal, Guid id);
        Task<CabinModal?> DeleteCabin(Guid id);
    }
}
