using LabsAndCoursesManagement.BusinessLogic.Commands;
using LabsAndCoursesManagement.BusinessLogic.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace LabsAndCoursesManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly IMediator mediator;

        public TenantsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        //[MustHavePermission(FSHAction.View, FSHResource.Tenants)]
        [OpenApiOperation("Get a list of all tenants.", "")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await mediator.Send(new GetAllTenantsRequest());
            if (result.IsFailure)
            {
                return StatusCode((int)result.StatusCode, result.Error);
            }
            return Ok(result.Entity);
        }

        //[HttpGet("{id}")]
        ////[MustHavePermission(FSHAction.View, FSHResource.Tenants)]
        //[OpenApiOperation("Get tenant details.", "")]
        //public Task<TenantDto> GetAsync(string id)
        //{
        //    return Mediator.Send(new GetTenantRequest(id));
        //}

        [HttpPost]
        //[MustHavePermission(FSHAction.Create, FSHResource.Tenants)]
        [OpenApiOperation("Create a new tenant.", "")]
        public async Task<IActionResult> Create(CreateTenantCommand request)
        {
            var result = await mediator.Send(request);
            if (result.IsFailure)
            {
                return StatusCode((int)result.StatusCode, result.Error);
            }
            return Ok(result.Entity);
        }

        //[HttpPost("{id}/activate")]
        ////[MustHavePermission(FSHAction.Update, FSHResource.Tenants)]
        //[OpenApiOperation("Activate a tenant.", "")]
        //[ApiConventionMethod(typeof(FSHApiConventions), nameof(FSHApiConventions.Register))]
        //public Task<string> ActivateAsync(string id)
        //{
        //    return Mediator.Send(new ActivateTenantRequest(id));
        //}

        //[HttpPost("{id}/deactivate")]
        ////[MustHavePermission(FSHAction.Update, FSHResource.Tenants)]
        //[OpenApiOperation("Deactivate a tenant.", "")]
        //[ApiConventionMethod(typeof(FSHApiConventions), nameof(FSHApiConventions.Register))]
        //public Task<string> DeactivateAsync(string id)
        //{
        //    return Mediator.Send(new DeactivateTenantRequest(id));
        //}

        //[HttpPost("{id}/upgrade")]
        ////[MustHavePermission(FSHAction.UpgradeSubscription, FSHResource.Tenants)]
        //[OpenApiOperation("Upgrade a tenant's subscription.", "")]
        //[ApiConventionMethod(typeof(FSHApiConventions), nameof(FSHApiConventions.Register))]
        //public async Task<ActionResult<string>> UpgradeSubscriptionAsync(string id, UpgradeSubscriptionRequest request)
        //{
        //    return id != request.TenantId
        //        ? BadRequest()
        //        : Ok(await Mediator.Send(request));
        //}
    }
}
