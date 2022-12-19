using FluentValidation;
using LabsAndCoursesManagement.Models.Dtos;

namespace LabsAndCoursesManagement.BusinessLogic.Validators
{
    public class CreateLabDtoValidator : AbstractValidator<CreateLabDto>
    {
        public CreateLabDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.Group)
                .NotEmpty()
                .Matches("^[A|B|X][1-5]$");
            RuleFor(x => x.Description)
                .MaximumLength(200);
            RuleFor(x => x.Year)
                .NotEmpty()
                .LessThan(7);
            RuleFor(x => x.Semester)
                .NotEmpty()
                .LessThan(3);
            RuleFor(x => x.TeacherId)
                .NotEmpty();
        }
    }
}
