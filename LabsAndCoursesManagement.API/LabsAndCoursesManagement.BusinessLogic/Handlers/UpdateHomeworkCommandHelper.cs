using LabsAndCoursesManagement.BusinessLogic.Commands;
using LabsAndCoursesManagement.BusinessLogic.Mappers;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Handlers
{
    public class UpdateHomeworkCommandHelper : IRequestHandler<UpdateHomeworkCommand, Result<Homework>>
    {
        private readonly IRepository<Homework> repository;

        public UpdateHomeworkCommandHelper(IRepository<Homework> repository)
        {
            this.repository = repository;
        }
        public async Task<Result<Homework>> Handle(UpdateHomeworkCommand request, CancellationToken cancellationToken)
        {
            var castedRequest = (CreateHomeworkCommand)request;
            var homeworkEntity = HomeworkMapper.Mapper.Map<Homework>(castedRequest);
            if (homeworkEntity == null)
            {
                return Result<Homework>.Failure(System.Net.HttpStatusCode.InternalServerError, "Issue with the mapper");
            }

            var newHomework = await repository.Update(request.Id, homeworkEntity);
            if (newHomework != null)
            {
                return Result<Homework>.Success(newHomework);
            }
            return Result<Homework>.Failure(System.Net.HttpStatusCode.InternalServerError, "Issue");
        }
    }

}
