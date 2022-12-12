using LabsAndCoursesManagement.BusinessLogic.Interfaces;
using LabsAndCoursesManagement.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LabsAndCoursesManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService service;

        public StudentsController(IStudentService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok((await service.GetAll()).Entity);
        }

        [HttpGet("{studentId:guid}")]
        public async Task<IActionResult> GetById(Guid studentId)
        {
            var result = await service.GetById(studentId);
            if (result.IsFailure)
            {
                return StatusCode((int)result.StatusCode, result.Error);
            }
            return Ok(result.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentDto dto)
        {
            var result = await service.Add(dto);
            if (result.IsFailure)
            {
                return StatusCode((int)result.StatusCode, result.Error);
            }
            return Created(nameof(Get), result.Entity);
        }

        [HttpDelete("{teacherId:guid}")]
        public async Task<IActionResult> DeleteById(Guid teacherId)
        {
            var result = await service.Delete(teacherId);
            if (result.IsFailure)
            {
                return StatusCode((int)result.StatusCode, result.Error);
            }
            return Ok();
        }

        [HttpPut("{studentId:guid}")]
        public async Task<IActionResult> Update(Guid studentId, [FromBody] CreateStudentDto dto)
        {
            var result = await service.Update(studentId, dto);
            if (result.IsFailure)
            {
                return StatusCode((int) result.StatusCode, result.Error);
            }
            return NoContent();
        }

        [HttpPut("{studentId:guid}/enroll")]
        public async Task<IActionResult> EnrollStudentToLabs(Guid studentId, [FromBody] List<Guid> labIds)
        {
            var result = await service.EnrollStudentToLabs(studentId, labIds);
            return Ok(result);
        }
    }
}
