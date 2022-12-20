using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Queries
{
    public class GetReportByIdQueryHandler : IRequestHandler<GetReportByIdQuery, Result<Report>>
    {
        private readonly IRepository<Report> repository;

        public GetReportByIdQueryHandler(IRepository<Report> repository)
        {
            this.repository = repository;
        }
        public async Task<Result<Report>> Handle(GetReportByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            if (entity == null)
            {
                return Result<Report>.Failure(System.Net.HttpStatusCode.NotFound, $"Could not find report with id {request.Id}");
            }
            return Result<Report>.Success(entity);

        }
    }
}
