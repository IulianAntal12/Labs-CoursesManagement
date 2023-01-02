using LabsAndCoursesManagement.BusinessLogic.Queries;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Handlers
{
    public class GetAllTenantsRequestHandler : IRequestHandler<GetAllTenantsRequest, Result<IEnumerable<Tenant>>>
    {
        private readonly IRepository<Tenant> repository;

        public GetAllTenantsRequestHandler(IRepository<Tenant> repository)
        {
            this.repository = repository;
        }
        public async Task<Result<IEnumerable<Tenant>>> Handle(GetAllTenantsRequest request, CancellationToken cancellationToken)
        {
            return Result<IEnumerable<Tenant>>.Success(await repository.All());
        }
    }
}
