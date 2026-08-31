using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationManagementSystem.Abstractions;

namespace CourseMSystem.Handler.Commands.CreateCourse
{
    public class CreateCourseCommand : ICommand
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
    }
}
