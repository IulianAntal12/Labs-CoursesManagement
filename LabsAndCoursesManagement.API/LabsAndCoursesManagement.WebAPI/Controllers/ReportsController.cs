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
    public class ReportsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ReportsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Report>>> Get()
        {
            var result = await mediator.Send(new GetAllReportsQuery());
            return Ok(result.Entity);
        }

        [HttpGet("{reportId:guid}")]
        public async Task<IActionResult> GetById(Guid reportId)
        {
            var result = await mediator.Send(new GetReportByIdQuery(reportId));
            if (result.IsFailure)
            {
                return StatusCode((int)result.StatusCode, result.Error);
            }
            return Ok(result.Entity);
        }


        [HttpPost]
        public async Task<ActionResult<Report>> Create([FromBody] CreateReportCommand command)
        {
            var result = await mediator.Send(command);
            if (result.IsFailure)
            {
                return StatusCode((int)result.StatusCode, result.Error);
            }
            return Created(nameof(Get), result.Entity);
        }

        [HttpPut]
        public async Task<ActionResult<Report>> Update(
           [FromBody] UpdateReportCommand command)
        {
            var result = await mediator.Send(command);
            if (result.IsFailure)
            {
                return StatusCode((int)result.StatusCode, result.Error);
            }
            return Ok(result.Entity);
        }

        [HttpDelete("{reportId:guid}")]
        public async Task<IActionResult> DeleteById(Guid reportId)
        {
            var result = await mediator.Send(new DeleteReportCommand(reportId));
            if (result.IsFailure)
            {
                return StatusCode((int)result.StatusCode, result.Error);
            }
            return Ok();
        }
    }
}
