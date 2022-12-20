using LabsAndCoursesManagement.BusinessLogic.Commands;
using LabsAndCoursesManagement.BusinessLogic.Mappers;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Handlers
{
    public class CreateHomeworkCommandHelper : IRequestHandler<CreateHomeworkCommand, Result<Homework>>
    {
        private readonly IRepository<Homework> repository;

        public CreateHomeworkCommandHelper(IRepository<Homework> repository)
        {
            this.repository = repository;
        }

        public async Task<Result<Homework>> Handle(CreateHomeworkCommand request, CancellationToken cancellationToken)
        {
            var reportEntity = ReportMapper.Mapper.Map<Homework>(request);
            if (reportEntity == null)
            {
                return Result<Homework>.Failure(System.Net.HttpStatusCode.InternalServerError, "Issue with the mapper");
            }

            var newReport = await repository.Add(reportEntity);
            if (newReport != null)
            {
                return Result<Homework>.Success(newReport);
            }
            return Result<Homework>.Failure(System.Net.HttpStatusCode.InternalServerError, "Issue");
        }
    }

}
