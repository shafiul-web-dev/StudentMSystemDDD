using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMSystem.Handler.Abstractions
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
