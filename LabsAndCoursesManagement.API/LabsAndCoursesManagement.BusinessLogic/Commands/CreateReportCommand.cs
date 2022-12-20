using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using MediatR;

namespace LabsAndCoursesManagement.BusinessLogic.Commands
{
    public class CreateReportCommand : IRequest<Result<Report>>
    {
        public Guid StudentId { get; set; }

        public Guid TeacherId { get; set; }

        public double Value { get; set; }

        public string EvaluationType { get; set; }

        public DateTime EvaluationDate { get; set; }
    }
}
