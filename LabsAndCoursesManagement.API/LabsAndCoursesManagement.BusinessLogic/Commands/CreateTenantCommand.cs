using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Commands
{
    public class CreateTenantCommand : IRequest<Result<Tenant>>
    {
        public string Name { get; set; }
    }
}
