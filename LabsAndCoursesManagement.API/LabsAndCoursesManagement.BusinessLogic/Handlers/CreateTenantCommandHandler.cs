

using LabsAndCoursesManagement.BusinessLogic.Commands;
using LabsAndCoursesManagement.BusinessLogic.Mappers;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Handlers
{
    public class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommand, Result<Tenant>>
    {
        private readonly IRepository<Tenant> repository;

        public CreateTenantCommandHandler(IRepository<Tenant> repository)
        {
            this.repository = repository;
        }

        public async Task<Result<Tenant>> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
        {
            var tenantEntity = ReportMapper.Mapper.Map<Tenant>(request);
            if (tenantEntity == null)
            {
                return Result<Tenant>.Failure(System.Net.HttpStatusCode.InternalServerError, "Issue with the mapper");
            }

            var newTenant = await repository.Add(tenantEntity);
            if (newTenant != null)
            {
                return Result<Tenant>.Success(newTenant);
            }
            return Result<Tenant>.Failure(System.Net.HttpStatusCode.InternalServerError, "Issue");

        }
    }
}
