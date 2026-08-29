using StudentMSystem.Handler.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMSystem.Handler.Queries.GetStudentById
{
    public class GetStudentByIdQuery : IQuery
    {
        public int Id { get; set; }
    }
}
