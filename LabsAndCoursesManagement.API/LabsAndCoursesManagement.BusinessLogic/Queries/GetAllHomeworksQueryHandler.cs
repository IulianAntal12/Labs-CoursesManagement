using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Queries
{
    public class GetAllHomeworksQueryHandler : IRequestHandler<GetAllHomeworksQuery, Result<IEnumerable<Homework>>>
    {
        private readonly IRepository<Homework> repository;

        public GetAllHomeworksQueryHandler(IRepository<Homework> repository)
        {
            this.repository = repository;
        }

        public async Task<Result<IEnumerable<Homework>>> Handle(GetAllHomeworksQuery request, CancellationToken cancellationToken)
        {
            return Result<IEnumerable<Homework>>.Success(await repository.All());
        }
    }
}