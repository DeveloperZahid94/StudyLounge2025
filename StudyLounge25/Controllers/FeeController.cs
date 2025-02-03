using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyLounge25.DomainModels;
using StudyLounge25.DTO;
using StudyLounge25.ServicesRepo.IServiceRepo;

namespace StudyLounge25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeeController : ControllerBase
    {
        private readonly IFee _ifee;

        public FeeController(IFee fee)
        {
            this._ifee = fee;
        }

        [HttpGet("GetFeeDetails")]
        public async Task<IActionResult> GetFeeDetails()
        {
            var feeModalData= await _ifee.GetFeeDetails();  
            return Ok(feeModalData);
        }

        [HttpPost("SubmitFeeDetails")]
        public async Task<IActionResult> SubmitFeeDetails([FromBody] FeeDto feeDto)
        {
            var feeDomainModal = new FeeModal()
            {
                PaymentDate = new DateTime(),
                PaymentStatus = feeDto.PaymentStatus,
                Amount = feeDto.Amount,
                StudentId=feeDto.StudentId,
            };

            var feeModalData = await _ifee.CreateFeeDetails(feeDomainModal);

            return Ok(feeModalData);
        }
    }
}
