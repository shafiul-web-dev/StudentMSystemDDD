using FluentValidation;
using StudentMSystem.Handler.Queries.LoginStudent;

namespace StudentMSystem.Handler.Validators
{
    public class LoginStudentValidator : AbstractValidator<LoginStudentQuery>
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
