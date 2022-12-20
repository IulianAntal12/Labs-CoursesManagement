using FluentValidation;
using LabsAndCoursesManagement.Models.Dtos;

namespace LabsAndCoursesManagement.BusinessLogic.Validators
{
    public class CreateCourseDtoValidator : AbstractValidator<CreateCourseDto>
    {
        public CreateCourseDtoValidator()
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
