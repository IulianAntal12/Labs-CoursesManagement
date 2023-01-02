using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Queries
{
    public class GetAllTenantsRequest : IRequest<Result<IEnumerable<Tenant>>>
    {
    }
}
