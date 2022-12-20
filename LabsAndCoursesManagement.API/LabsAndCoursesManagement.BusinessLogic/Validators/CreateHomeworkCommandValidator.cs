using FluentValidation;
using LabsAndCoursesManagement.BusinessLogic.Commands;

namespace LabsAndCoursesManagement.BusinessLogic.Validators
{
    public class CreateHomeworkCommandValidator : AbstractValidator<CreateHomeworkCommand>
    {
        public CreateHomeworkCommandValidator()
        {
            RuleFor(e => e.Description).NotEmpty();
            RuleFor(e => e.Value).NotEmpty().GreaterThan(0).LessThan(11);
            RuleFor(e => e.Bonus).NotEmpty().GreaterThan(0).LessThan(2);
        }
    }
}
