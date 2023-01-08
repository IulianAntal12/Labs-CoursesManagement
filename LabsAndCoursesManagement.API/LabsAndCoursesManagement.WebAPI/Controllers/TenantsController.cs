using LabsAndCoursesManagement.BusinessLogic.Multitenancy;
using LabsAndCoursesManagement.BusinessLogic.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LabsAndCoursesManagement.WebAPI.Controllers
{
    [Route("api/v{version:apiVersion}/tenants")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TenantsController : ControllerBase
    {
        private readonly IMediator mediator;

        public TenantsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<TenantSettings>> Get()
        {
            var result = await mediator.Send(new GetTenantSettingsQuery());
            return Ok(result.Entity);
        }
    }
}
