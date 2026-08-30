using EducationManagementSystem.Abstractions;

namespace StudentMSystem.Handler.Queries.LoginStudent
{
    public class LoginStudentQuery : IQuery
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}