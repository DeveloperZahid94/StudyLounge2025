using Microsoft.EntityFrameworkCore;
using StudyLounge25.Data;
using StudyLounge25.DomainModels;
using StudyLounge25.DTO;
using StudyLounge25.ServicesRepo.IServiceRepo;

namespace StudyLounge25.ServicesRepo.Repositories
{
    public class CabinRepo : ICabin
    {
        private readonly SLdbContext _sLdbContext;

        public CabinRepo(SLdbContext sLdbContext)
        {
            this._sLdbContext = sLdbContext;
        }

        public async Task<CabinModal?> AddCabin(CabinModal cabinModal)
        {
            await _sLdbContext.Cabins.AddAsync(cabinModal);
            await _sLdbContext.SaveChangesAsync();
            return cabinModal;
        }

        public async Task<List<CabinModal>> GetAllCabins()
        {
            return await _sLdbContext.Cabins.ToListAsync();

        }

        public async Task<CabinModal?> GetCabinById(Guid id)
        {
            var cabinExists= await _sLdbContext.Cabins.FirstOrDefaultAsync(x=>x.CabinId==id);
            if (cabinExists == null)
            {
                return null;
            }
            return cabinExists;
        }

        public async Task<CabinModal?> UpdateCabin(CabinModal cabinModal, Guid id)
        {
            var cabin = await _sLdbContext.Cabins.FirstOrDefaultAsync(x => x.CabinId == id);
            if(cabin == null)
            {
                return null;
            }
            cabin.CabinName=cabinModal.CabinName;
            cabin.Description=cabinModal.Description;
            cabin.PricePerDay=cabinModal.PricePerDay;
            cabin.HasWifi=cabinModal.HasWifi;
            cabin.HasAc=cabinModal.HasAc;
            cabin.IsAvailable=cabinModal.IsAvailable;
            await _sLdbContext.SaveChangesAsync();
            return cabin;
        }

        public async Task<CabinModal?> DeleteCabin( Guid id)
        {
            var cabin = await _sLdbContext.Cabins.FirstOrDefaultAsync(x => x.CabinId == id);
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
