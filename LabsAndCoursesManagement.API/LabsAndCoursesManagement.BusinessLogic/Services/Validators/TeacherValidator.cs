using FluentValidation;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.BusinessLogic.Services.Validators
{
    public class TeacherValidator : AbstractValidator<Teacher>
    {
        public TeacherValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(50)
                .Must(BeAValidFullName)
                .WithMessage("Please enter first name and last name");
            RuleFor(x => x.Email)
                .NotEmpty()
                .Matches("^[a-z|A-Z|0-9|_]+@[a-z]+\\.[a-z]+$");
            RuleFor(x => x.Role)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.PhoneNumber)
                .Matches("^(\\+4|)?(07[0-8]{1}[0-9]{1}|02[0-9]{2}|03[0-9]{2}){1}?(\\s|\\.|\\$-)?([0-9]{3}(\\s|\\.|\\-|)){2}");
            RuleFor(x => x.Cabinet)
                .MaximumLength(4);
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
