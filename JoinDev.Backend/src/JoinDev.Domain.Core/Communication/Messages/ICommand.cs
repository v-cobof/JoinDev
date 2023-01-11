using JoinDev.Domain.Core.Validation.Results;
using MediatR;

namespace JoinDev.Domain.Core.Communication.Messages
{
    public interface ICommand : IRequest<CommandResult>
    {
    }
}
