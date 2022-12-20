using LabsAndCoursesManagement.BusinessLogic.Commands;
using LabsAndCoursesManagement.BusinessLogic.Queries;
using LabsAndCoursesManagement.Models.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LabsAndCoursesManagement.WebAPI.Controllers
{
    [Route("api/v{version:apiVersion}/reports")]
    [ApiController]
    [ApiVersion("1.0")]
    public class HomeworkController : ControllerBase
    {
        private readonly IMediator mediator;

        public HomeworkController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Homework>>> Get()
        {
            var result = await mediator.Send(new GetAllHomeworksQuery());
            return Ok(result.Entity);
        }

        [HttpGet("{homeworkId:guid}")]
        public async Task<IActionResult> GetById(Guid homeworkId)
        {
            var result = await mediator.Send(new GetHomeworkByIdQuery(homeworkId));
            if (result.IsFailure)
            {
                return StatusCode((int)result.StatusCode, result.Error);
            }
            return Ok(result.Entity);
        }


        [HttpPost]
        public async Task<ActionResult<Homework>> Create([FromBody] CreateHomeworkCommand command)
        {
            var result = await mediator.Send(command);
            if (result.IsFailure)
            {
                return StatusCode((int)result.StatusCode, result.Error);
            }
            return Created(nameof(Get), result.Entity);
        }

        [HttpPut]
        public async Task<ActionResult<Homework>> Update(
           [FromBody] UpdateHomeworkCommand command)
        {
            var result = await mediator.Send(command);
            if (result.IsFailure)
            {
                return StatusCode((int)result.StatusCode, result.Error);
            }
            return Ok(result.Entity);
        }

        [HttpDelete("{homweorkId:guid}")]
        public async Task<IActionResult> DeleteById(Guid homeworkId)
        {
            var result = await mediator.Send(new DeleteHomeworkCommand(homeworkId));
            if (result.IsFailure)
            {
                return StatusCode((int)result.StatusCode, result.Error);
            }
            return Ok();
        }
    }
}
