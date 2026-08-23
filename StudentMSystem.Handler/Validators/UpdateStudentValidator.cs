using FluentValidation;
using StudentMSystem.DTO.Student;

namespace StudentMSystem.Handler.Validators
{
    public class UpdateStudentValidator : AbstractValidator<UpdateStudentDto>
    {
        public UpdateStudentValidator()
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

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Phone number is required.")
                .Matches(@"^01[3-9][0-9]{8}$")
                .WithMessage("Phone number must be a valid 11-digit Bangladesh mobile number.");

            // Department validation
            RuleFor(x => x.Department)
                .NotEmpty()
                .WithMessage("Department is required.")
                .MaximumLength(100)
                .WithMessage("Department cannot exceed 100 characters.");
        }
    }
}
