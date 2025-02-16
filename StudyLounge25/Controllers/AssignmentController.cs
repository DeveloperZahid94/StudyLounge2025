﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyLounge25.DomainModels;
using StudyLounge25.DTO;
using StudyLounge25.ServicesRepo.IServiceRepo;

namespace StudyLounge25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IAssignment _iassignment;
        public AssignmentController(IMapper mapper,IAssignment assignment) 
        {
            this._mapper = mapper;
            this._iassignment = assignment;
        }
       

        [HttpGet("GetAssignments")]
        public async Task<IActionResult> GetAllAssignments()
        {
            var cabinModal = await _iassignment.GetAllAssignments();
            
            var assignmentsDto = cabinModal.Select(a => new AssignmentFetchDto
            {
                AssignmentId = a.AssignmentId,
                StudentId = a.StudentId ?? Guid.Empty,  
                StudentName = a.Student?.FirstName + " " + a.Student?.LastName, 
                CabinId = a.CabinId ?? Guid.Empty,  
                CabinName = a.Cabin?.CabinName,  
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                AssignmentStatus = a.AssignmentStatus,
                amountToPay= (a.Cabin?.PricePerDay ?? 0) *
                             ((a.EndDate.HasValue && a.StartDate.HasValue) ? (a.EndDate.Value - a.StartDate.Value).Days : 0)
            }).ToList(); 

            return Ok(assignmentsDto); 
            //return Ok(_mapper.Map<List<AssignmentFetchDto>>(cabinModal));

        }



        [HttpPost("AddAssignment")]
        public async Task<IActionResult> AddAssignment([FromBody] AssignmentSaveDto assignmentSaveDto)
        {
            
            var cabinAssg = new CabinAssignmentModal
            {
                StudentId=assignmentSaveDto.StudentId,
                CabinId = assignmentSaveDto.CabinId,
                StartDate = assignmentSaveDto.StartDate,
                EndDate = assignmentSaveDto.EndDate,
                AssignmentStatus = assignmentSaveDto.AssignmentStatus,
            };
            await _iassignment.AddAssignment(cabinAssg);
            return Ok("created");

        }

        [HttpPut("UpdateAssignmnet{id}")]
        public async Task<IActionResult> UpdateAssignmnet([FromBody] AssignmentSaveDto assignmentSaveDto, [FromRoute] Guid id)
        {
            var cabinAssg = new CabinAssignmentModal
            {
                StudentId = assignmentSaveDto.StudentId,
                CabinId = assignmentSaveDto.CabinId,
                StartDate = assignmentSaveDto.StartDate,
                EndDate = assignmentSaveDto.EndDate,
                AssignmentStatus = assignmentSaveDto.AssignmentStatus,
            };
            var cabinExist = await _iassignment.UpdateAssignmnet(cabinAssg, id);
            if (cabinExist == null)
            {
                return NotFound();
            }
            return Ok(cabinAssg);

        }

        [HttpDelete("DeleteAssignment{id}")]
        public async Task<IActionResult> DeleteAssignment([FromRoute] Guid id)
        {
            var assgExist = await _iassignment.DeleteAssignment(id);
            if (assgExist == null)
            {
                return NotFound();
            }
            return Ok(assgExist);

        }
    }
}
