using LabsAndCoursesManagement.BusinessLogic.Interfaces;
using LabsAndCoursesManagement.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LabsAndCoursesManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabsController : ControllerBase
    {
        private readonly ILabService service;

        public LabsController(ILabService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok((await service.GetAll()).Entity);
        }

        [HttpGet("{labId:guid}")]
        public async Task<IActionResult> GetById(Guid labId)
        {
            var result = await service.GetById(labId);
            if (result.IsFailure)
            {
                return StatusCode((int)result.StatusCode, result.Error);
            }
            return Ok(result.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLabDto dto)
        {
            var result = await service.Add(dto);
            if (result.IsFailure)
            {
                return StatusCode((int)result.StatusCode, result.Error);
            }
            return Created(nameof(Get), result.Entity);
        }

        [HttpDelete("{labId:guid}")]
        public async Task<IActionResult> DeleteById(Guid labId)
        {
            var result = await service.Delete(labId);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok();
        }

        [HttpPut("{labId:guid}")]
        public async Task<IActionResult> Update(Guid labId, [FromBody] CreateLabDto dto)
        {
            var result = await service.Update(labId, dto);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok();
        }
    }
}
