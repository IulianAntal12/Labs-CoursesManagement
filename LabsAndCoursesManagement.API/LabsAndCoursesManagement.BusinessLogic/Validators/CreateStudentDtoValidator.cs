using FluentValidation;
using LabsAndCoursesManagement.Models.Dtos;

namespace LabsAndCoursesManagement.BusinessLogic.Validators
{
    public class CreateStudentDtoValidator : AbstractValidator<CreateStudentDto>
    {
        public CreateStudentDtoValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(50)
                .Must(BeAValidFullName)
                .WithMessage("Please enter first name and last name");
            RuleFor(x => x.Email)
                .NotEmpty()
                .Matches("^[a-z|A-Z|0-9|_|.]+@[a-z]+\\.[a-z]+$");
            RuleFor(x => x.Year)
                .NotEmpty()
                .LessThan(7);
            RuleFor(x => x.IdentificationNumber)
                .NotEmpty()
                .Matches("^[0-9]{9}[A-Z]{3}[0-9]{6}$");
            RuleFor(x => x.Group)
                .NotEmpty()
                .Matches("^[A|B|X][1-5]$");
        }

        private bool BeAValidFullName(string fullName)
        {
            string[] fullNameComponents = fullName.Split(" ");
            if (fullNameComponents.Length < 2)
                return false;
            if (fullNameComponents[0].Length < 1 || fullNameComponents[1].Length < 1)
                return false;
            return true;
        }
    }
}
