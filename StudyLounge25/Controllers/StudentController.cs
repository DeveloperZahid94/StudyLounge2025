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

        [HttpPost("Addstudent")]
        public async Task<IActionResult> AddStudent([FromBody] StudentSaveDto studentSaveDto)
        {
            var studentModal = new StudentModal
            {
                FirstName = studentSaveDto.FirstName,
                LastName = studentSaveDto.LastName,
                Address = studentSaveDto.Address,
                DateOfBirth = studentSaveDto.DateOfBirth,
                Email = studentSaveDto.Email,
                PhoneNumber = studentSaveDto.PhoneNumber,
                RegistrationDate = studentSaveDto.RegistrationDate,
                Status = studentSaveDto.Status,
            };
            await _istudent.AddStudent(studentModal);
            return Ok(studentModal);
        }

        [HttpPut("Updatestudent{id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute]Guid id, [FromBody] StudentSaveDto studentSaveDto)
        {
            var studentModal = new StudentModal
            {
                FirstName = studentSaveDto.FirstName,
                LastName = studentSaveDto.LastName,
                Address = studentSaveDto.Address,
                DateOfBirth = studentSaveDto.DateOfBirth,
                Email = studentSaveDto.Email,
                PhoneNumber = studentSaveDto.PhoneNumber,
                RegistrationDate = studentSaveDto.RegistrationDate,
                Status = studentSaveDto.Status,
            };
            var res = await _istudent.UpdateStudentDetails(id, studentModal);
            if(res == null)
            {
                return NotFound();
            }
           
            
            return Ok(studentSaveDto);
        }
        [HttpDelete("deletestudent{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var resp = await _istudent.DeleteStudent(id);
            if(resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }
    }
}
