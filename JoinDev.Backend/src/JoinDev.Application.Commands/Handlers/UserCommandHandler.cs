using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Validation.Results;
using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;
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
        public UserCommandHandler(IUnitOfWork uow, IMediatorHandler mediator) : base(uow, mediator)
        {
        }

        public async override Task<CommandResult> Execute(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.UserFactory.CreateUserToRegister(request.Email, request.FullName, request.Password);

            

            if (_uow.Users.GetByEmail(request.Email) != null)
            {
                await Notify(request, "The user e-mail has already been taken.");

                return CommandResult.Failure();
            }

            // adicionar domain event na entidade

            // persistir o user

            // commit
        }
    }
}
