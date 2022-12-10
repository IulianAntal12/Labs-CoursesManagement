using FluentValidation;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.BusinessLogic.Services.Validators
{
    public class LabValidator : AbstractValidator<Lab>
    {
        public LabValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.Group)
                .NotEmpty()
                .Matches("^(A|B|X)(1-5)$");
            RuleFor(x => x.Description)
                .MaximumLength(200);
            RuleFor(x => x.Year)
                .NotEmpty()
                .LessThan(7);
            RuleFor(x => x.Semester)
                .NotEmpty()
                .LessThan(3);
            RuleFor(x => x.Teacher)
                .NotNull();
        }
    }
}
