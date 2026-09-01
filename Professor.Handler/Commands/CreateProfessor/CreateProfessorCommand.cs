using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationManagementSystem.Abstractions;


namespace ProfessorMSystem.Handler.Commands.CreateProfessor
{
    public class CreateProfessorCommand : ICommand
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;

    }
}
