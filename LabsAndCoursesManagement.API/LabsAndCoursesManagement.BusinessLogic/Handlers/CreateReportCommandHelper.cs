using LabsAndCoursesManagement.BusinessLogic.Commands;
using LabsAndCoursesManagement.BusinessLogic.Mappers;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Handlers
{
    public class CreateReportCommandHelper : IRequestHandler<CreateReportCommand, Result<Report>>
    {
        private readonly IRepository<Report> repository;

        public CreateReportCommandHelper(IRepository<Report> repository)
        {
            this.repository = repository;
        }

        public async Task<Result<Report>> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            var homeworkEntity = ReportMapper.Mapper.Map<Report>(request);
            if (homeworkEntity == null)
            {
                return Result<Report>.Failure(System.Net.HttpStatusCode.InternalServerError, "Issue with the mapper");
            }

            var newHomework = await repository.Add(homeworkEntity);
            if (newHomework != null)
            {
                return Result<Report>.Success(newHomework);
            }
            return Result<Report>.Failure(System.Net.HttpStatusCode.InternalServerError, "Issue");
        }
    }
}
