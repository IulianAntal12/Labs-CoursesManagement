using FluentValidation;
using LabsAndCoursesManagement.BusinessLogic.Commands;

namespace LabsAndCoursesManagement.BusinessLogic.Validators
{
    public class UpdateHomeworkCommandValidator : AbstractValidator<UpdateHomeworkCommand>
    {
        public UpdateHomeworkCommandValidator()
        {
            RuleFor(e => e.Description).NotEmpty();
            RuleFor(e => e.Value).NotEmpty().GreaterThan(0).LessThan(11);
            RuleFor(e => e.Bonus).NotEmpty().GreaterThan(0).LessThan(2);
            RuleFor(e => e.Id).NotNull().NotEmpty();
        }
    }
}
