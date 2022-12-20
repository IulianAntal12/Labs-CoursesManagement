using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Queries
{
    public class GetAllHomeworksQuery : IRequest<Result<IEnumerable<Homework>>>
    {
    }
}
