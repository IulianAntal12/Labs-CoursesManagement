using LabsAndCoursesManagement.BusinessLogic.Commands;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Handlers
{
    public class DeleteReportCommandHelper : IRequestHandler<DeleteReportCommand, Result<Report>>
    {
        private readonly IRepository<Report> repository;

        public DeleteReportCommandHelper(IRepository<Report> repository)
        {
            this.repository = repository;
        }
        public async Task<Result<Report>> Handle(DeleteReportCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            if (entity == null)
            {
                return Result<Report>.Failure(System.Net.HttpStatusCode.NotFound, $"Could not find report with id {request.Id}");
            }
            await repository.Delete(entity);
            return Result<Report>.SuccessNoEntity();
        }
    }
}
