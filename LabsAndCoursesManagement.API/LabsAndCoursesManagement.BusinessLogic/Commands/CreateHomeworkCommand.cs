using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Commands
{
    public class CreateHomeworkCommand : IRequest<Result<Homework>>
    {
        public double Value { get; set; }
        public string Description { get; set; }
        public double Bonus { get; set; }
    }
}
