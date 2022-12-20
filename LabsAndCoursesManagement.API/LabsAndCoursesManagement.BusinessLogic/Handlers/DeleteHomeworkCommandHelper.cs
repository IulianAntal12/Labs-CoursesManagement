using LabsAndCoursesManagement.BusinessLogic.Commands;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Handlers
{
    public class DeleteHomeworkCommandHelper : IRequestHandler<DeleteHomeworkCommand, Result<Homework>>
    {
        private readonly IRepository<Homework> repository;

        public DeleteHomeworkCommandHelper(IRepository<Homework> repository)
        {
            this.repository = repository;
        }
        public async Task<Result<Homework>> Handle(DeleteHomeworkCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            if (entity == null)
            {
                return Result<Homework>.Failure(System.Net.HttpStatusCode.NotFound, $"Could not find homework with id {request.Id}");
            }
            await repository.Delete(entity);
            return Result<Homework>.SuccessNoEntity();
        }
    }

}
