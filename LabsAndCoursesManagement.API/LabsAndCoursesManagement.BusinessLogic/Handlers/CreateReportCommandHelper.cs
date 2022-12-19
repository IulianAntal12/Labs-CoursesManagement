using LabsAndCoursesManagement.BusinessLogic.Commands;
using LabsAndCoursesManagement.BusinessLogic.Mappers;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Handlers
{
    public class CreateReportCommandHelper: IRequestHandler<CreateReportCommand, Result<Report>>
    {
        private readonly IRepository<Report> repository;

        public CreateReportCommandHelper(IRepository<Report> repository)
        {
            this.repository = repository;
        }

        public async Task<Result<Report>> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            var reportEntity = ReportMapper.Mapper.Map<Report>(request);
            if (reportEntity == null)
            {
                return Result<Report>.Failure(System.Net.HttpStatusCode.InternalServerError, "Issue with the mapper");
            }

            var newReport = await repository.Add(reportEntity);
            return Result<Report>.Success(newReport);
        }
    }
}
