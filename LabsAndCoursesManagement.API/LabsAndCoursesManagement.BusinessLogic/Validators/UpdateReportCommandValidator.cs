using FluentValidation;
using LabsAndCoursesManagement.BusinessLogic.Commands;

namespace LabsAndCoursesManagement.BusinessLogic.Validators
{
    public class UpdateReportCommandValidator : AbstractValidator<UpdateReportCommand>
    {
        public UpdateReportCommandValidator()
        {
            RuleFor(e => e.StudentId).NotEmpty();
            RuleFor(e => e.TeacherId).NotEmpty();
            RuleFor(e => e.Value).NotEmpty().InclusiveBetween(1, 10);
            RuleFor(e => e.EvaluationType).NotEmpty().MaximumLength(10);
            RuleFor(e => e.EvaluationDate).NotEmpty();
            RuleFor(e => e.Id).NotEmpty();
        }
    }
}
