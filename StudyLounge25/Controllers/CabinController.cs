using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyLounge25.DomainModels;
using StudyLounge25.DTO;
using StudyLounge25.ServicesRepo.IServiceRepo;

namespace StudyLounge25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICabin _icabin;

        public CabinController(IMapper mapper,ICabin cabin)
        {
            this._mapper = mapper;
            this._icabin = cabin;
        }

        [HttpGet("GetCabins")]
        public async Task<IActionResult> GetAllCabins()
        {
            var cabinModal=await _icabin.GetAllCabins();
            return Ok(cabinModal);

        }

        [HttpGet("GetCabinById{id}")]
        public async Task<IActionResult> GetCabinById([FromRoute] Guid id)
        {
            var cabinFound = await _icabin.GetCabinById(id);
            if (cabinFound == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CabinFetchDto>(cabinFound));

        }

        [HttpPost("AddCabin")]
        public async Task<IActionResult> AddCabin([FromBody] CabinAddDto cabinAddDto)
        {
            var cabin = new CabinModal
            {
                CabinName = cabinAddDto.CabinName,
                Description = cabinAddDto.Description,
                HasAc = cabinAddDto.HasAc,
                HasWifi = cabinAddDto.HasWifi,
                PricePerDay = cabinAddDto.PricePerDay,
                IsAvailable = cabinAddDto.IsAvailable,
            };
            await _icabin.AddCabin(cabin);
            return Ok(cabin);
            
        }

        [HttpPut("updateCabin{id}")]
        public async Task<IActionResult> UpdateCabin([FromBody] CabinAddDto cabinAddDto, [FromRoute] Guid id)
        {
            var cabin = new CabinModal
            {
                CabinName = cabinAddDto.CabinName,
                Description = cabinAddDto.Description,
                HasAc = cabinAddDto.HasAc,
                HasWifi = cabinAddDto.HasWifi,
                PricePerDay = cabinAddDto.PricePerDay,
                IsAvailable = cabinAddDto.IsAvailable,
            };
            var cabinExist = await _icabin.UpdateCabin(cabin, id);
            if (cabinExist == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CabinFetchDto>(cabinExist));

        }

        [HttpDelete("deleteCabin{id}")]
        public async Task<IActionResult> DeleteCabin([FromRoute] Guid id)
        {
            var cabinExist = await _icabin.DeleteCabin(id);
            if (cabinExist == null)
            {
                return NotFound();
            }
            return Ok(cabinExist);

        }

    }
}
