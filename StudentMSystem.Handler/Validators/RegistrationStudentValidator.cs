using FluentValidation;
using StudentMSystem.DTO.Student;

namespace StudentMSystem.Handler.Validators
{
    public class RegistrationStudentValidator: AbstractValidator<RegistrationStudentDto>
    {
        public RegistrationStudentValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .MaximumLength(100)
                .WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.")
                .MaximumLength(150)
                .WithMessage("Email cannot exceed 150 characters.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters.")
                .MaximumLength(20)
                .WithMessage("Password must not exceed 20 characters.")
                .Matches("[a-z]")
                .WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[A-Z]")
                .WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[0-9]")
                .WithMessage("Password must contain at least one number.")
                .Matches(@"[^a-zA-Z0-9\s]")
                .WithMessage("Password must contain at least one special character.")
                .Matches(@"^\S+$")
                .WithMessage("Password must not contain spaces.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Phone number is required.")
                .Matches(@"^01[3-9][0-9]{8}$")
                .WithMessage("Phone number must be a valid 11-digit Bangladesh mobile number.");

            RuleFor(x => x.Department)
                .NotEmpty()
                .WithMessage("Department is required.")
                .MaximumLength(100)
                .WithMessage("Department cannot exceed 100 characters.");
        }
    }
}