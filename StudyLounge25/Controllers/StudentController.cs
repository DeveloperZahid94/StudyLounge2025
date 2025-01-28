using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyLounge25.DTO;
using StudyLounge25.ServicesRepo.IServiceRepo;

namespace StudyLounge25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _istudent;
        private readonly IMapper _mapper;

        public StudentController(IStudent student,IMapper mapper )
        {
            this._istudent = student;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetStudents()
        {
            var studentModal = await _istudent.GetAll();
            var studentDto = _mapper.Map<List<studentDTO>>(studentModal);
            return Ok(studentDto);

        }
    }
}
