using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Queries
{
    public class GetHomeworkByIdQueryHandler : IRequestHandler<GetHomeworkByIdQuery, Result<Homework>>
    {
        private readonly IRepository<Homework> repository;

        public GetHomeworkByIdQueryHandler(IRepository<Homework> repository)
        {
            this.repository = repository;
        }
        public async Task<Result<Homework>> Handle(GetHomeworkByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            if (entity == null)
            {
                return Result<Homework>.Failure(System.Net.HttpStatusCode.NotFound, $"Could not find report with id {request.Id}");
            }
            return Result<Homework>.Success(entity);

        }
    }
}
