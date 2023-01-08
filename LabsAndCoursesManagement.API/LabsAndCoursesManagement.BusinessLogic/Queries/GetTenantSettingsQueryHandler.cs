using LabsAndCoursesManagement.BusinessLogic.Multitenancy;
using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.Models.Helpers;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Queries
{
    public class GetTenantSettingsQueryHandler : IRequestHandler<GetTenantSettingsQuery, Result<TenantSettings>>
    {
        private readonly ITenantContext context;

        public GetTenantSettingsQueryHandler(ITenantContext context)
        {
            this.context = context;
        }

        public async Task<Result<TenantSettings>> Handle(GetTenantSettingsQuery request, CancellationToken cancellationToken)
        {
            var tenantSetttings = TenantResolver.GetByTenantName(context.CurrentTenant);
            if (tenantSetttings == null)
            {
                return Result<TenantSettings>.Failure(System.Net.HttpStatusCode.NotFound, $"Could not find tenant with name {context.CurrentTenant}");
            }
            return Result<TenantSettings>.Success(tenantSetttings);
        }
    }
}
