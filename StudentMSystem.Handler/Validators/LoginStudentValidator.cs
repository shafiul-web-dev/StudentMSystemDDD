using FluentValidation;
using StudentMSystem.DTO.Student;

namespace StudentMSystem.Handler.Validators
{
    public class LoginStudentValidator : AbstractValidator<LoginStudentDto>
    {
        public LoginStudentValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Invalid Email Format");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is Required");
        }
    }
}
