using JoinDev.Domain.Core.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Domain.Core.Communication.Messages
{
    public abstract class Query<T> : Message, IRequest<QueryResult<T>>
    {
    }
}
