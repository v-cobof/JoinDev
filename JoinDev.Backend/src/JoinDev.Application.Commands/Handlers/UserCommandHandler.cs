using JoinDev.Domain.Core.Validation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Commands.Handlers
{
    public class UserCommandHandler : BaseCommandHandler<CreateUserCommand, CommandResult>
    {
        public override Task<CommandResult> Execute(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(CommandResult.Successful());
        }
    }
}
