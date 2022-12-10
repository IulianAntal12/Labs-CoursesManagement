using FluentValidation;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.BusinessLogic.Services.Validators
{
    public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.Description)
                .MaximumLength(200);
            RuleFor(x => x.Year)
                .NotEmpty()
                .LessThan(7);
            RuleFor(x => x.Semester)
                .NotEmpty()
                .LessThan(3);
        }
    }
}
