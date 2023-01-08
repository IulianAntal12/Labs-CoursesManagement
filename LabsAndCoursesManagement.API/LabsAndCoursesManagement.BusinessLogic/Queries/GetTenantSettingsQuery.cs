using LabsAndCoursesManagement.BusinessLogic.Multitenancy;
using LabsAndCoursesManagement.Models.Helpers;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Queries
{
    public class GetTenantSettingsQuery : IRequest<Result<TenantSettings>>
    {
    }
}
