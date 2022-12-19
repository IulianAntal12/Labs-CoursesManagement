using LabsAndCoursesManagement.BusinessLogic.Commands;
using LabsAndCoursesManagement.BusinessLogic.Mappers;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Handlers
{
    public class UpdateReportCommandHelper : IRequestHandler<UpdateReportCommand, Result<Report>>
    {
        private readonly IRepository<Report> repository;

        public UpdateReportCommandHelper(IRepository<Report> repository)
        {
            this.repository = repository;
        }
        public async Task<Result<Report>> Handle(UpdateReportCommand request, CancellationToken cancellationToken)
        {
            var castedRequest = (CreateReportCommand) request;
            var reportEntity = ReportMapper.Mapper.Map<Report>(castedRequest);
            if (reportEntity == null)
            {
                return Result<Report>.Failure(System.Net.HttpStatusCode.InternalServerError, "Issue with the mapper");
            }

            var newReport = await repository.Update(request.Id, reportEntity);
            return Result<Report>.Success(newReport);  
        }
    }
}
