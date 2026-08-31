using EducationManagementSystem.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMSystem.Handler.Queries.GetCourseById
{
    public class GetCourseByIdQuery : IQuery
    {
        public int Id { get; set; }
    }
}
