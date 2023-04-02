using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Domain.Core.Results
{
    public class QueryResult<T>
    {
        public T Result { get; set; }
        public bool Success { get; set; }

        public QueryResult(T result)
        {
            Result = result;
            Success = true;
        }

        private QueryResult() { }

        public static QueryResult<T> Failure()
        {
            return new QueryResult<T>();
        }

        public static implicit operator QueryResult<T>(T result) => new(result);
    }
}
