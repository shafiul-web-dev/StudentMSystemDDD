using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentMSystem.Handler.Abstractions;

namespace StudentMSystem.Handler.Commands.RegistrationStudent
{
    public class RegistrationStudentCommand : ICommand
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

    }
}
