using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Queries
{
    public class GetAllReportsQueryHandler : IRequestHandler<GetAllReportsQuery, Result<IEnumerable<Report>>>
    {
        private readonly IRepository<Report> repository;

        public GetAllReportsQueryHandler(IRepository<Report> repository)
        {
            this.repository = repository;
        }

        public async Task<Result<IEnumerable<Report>>> Handle(GetAllReportsQuery request, CancellationToken cancellationToken)
        {
            return Result<IEnumerable<Report>>.Success(await repository.All());
        }


    }
}
