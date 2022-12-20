using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Commands
{
    public class DeleteReportCommand : IRequest<Result<Report>>
    {
        public DeleteReportCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
