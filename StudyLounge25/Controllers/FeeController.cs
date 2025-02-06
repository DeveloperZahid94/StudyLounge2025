using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyLounge25.DomainModels;
using StudyLounge25.DTO;
using StudyLounge25.ServicesRepo.IServiceRepo;
using System.Text.Json;

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

        [HttpGet("GetFeeDetails{id}")]
        public async Task<IActionResult> GetFeeDetailsById([FromRoute] Guid id)
        {
            var feeDetailDto = await _ifee.GetFeeDetailsById(id);
            return Ok(feeDetailDto);
        }
        [HttpGet("GetFullDetailsById{searchTerm}")]
        public async Task<IActionResult> GetFullDetailsById([FromRoute] string searchTerm)
        {
            var FullDetailDto = await _ifee.GetFullDetailsById(searchTerm);
            // Set up JsonSerializerOptions to handle circular references
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
                WriteIndented = true // Pretty print for JSON
            };

            // Serialize the result with circular reference handling
            var jsonResponse = JsonSerializer.Serialize(FullDetailDto, options);

            // Return the JSON response
            return Content(jsonResponse, "application/json");
        }
        

        [HttpPost("SubmitFeeDetails")]
        public async Task<IActionResult> SubmitFeeDetails([FromBody] FeeDto feeDto)
        {
            var feeDomainModal = new FeeModal()
            {
                PaymentDate = feeDto.PaymentDate,
                PaymentStatus = feeDto.PaymentStatus,
                Amount = feeDto.Amount,
                StudentId=feeDto.StudentId,

            };

            var feeModalData = await _ifee.CreateFeeDetails(feeDomainModal);

            return Ok(feeModalData);
        }
    }
}
