using FluentValidation;
using LabsAndCoursesManagement.BusinessLogic.Commands;

namespace LabsAndCoursesManagement.BusinessLogic.Validators
{
    public class CreateReportCommandValidator : AbstractValidator<CreateReportCommand>
    {
        public CreateReportCommandValidator()
        {
            RuleFor(e => e.StudentId).NotEmpty();
            RuleFor(e => e.TeacherId).NotEmpty();
            RuleFor(e => e.Value).NotEmpty().InclusiveBetween(1, 10);
            RuleFor(e => e.EvaluationType).NotEmpty().MaximumLength(10);
            RuleFor(e => e.EvaluationDate).NotEmpty();
        }
    }
}
