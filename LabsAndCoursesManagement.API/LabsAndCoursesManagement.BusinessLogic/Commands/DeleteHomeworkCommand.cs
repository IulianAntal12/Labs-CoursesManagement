using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Commands
{
    public class DeleteHomeworkCommand : IRequest<Result<Homework>>
    {
        public Guid Id { get; set; }
        public DeleteHomeworkCommand(Guid id)
        {
            Id = id;
        }
    }
}
