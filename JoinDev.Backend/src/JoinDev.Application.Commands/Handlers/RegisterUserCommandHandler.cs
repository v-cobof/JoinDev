using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Validation.Results;
using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;
using JoinDev.Application.Events;

namespace JoinDev.Application.Commands.Handlers
{
    public class RegisterUserCommandHandler : BaseCommandHandler<RegisterUserCommand, CommandResult>
    {
        public RegisterUserCommandHandler(IUnitOfWork uow, IBusHandler bus) : base(uow, bus)
        {
        }

        public async override Task<CommandResult> Execute(RegisterUserCommand request)
        {
            var user = User.UserFactory.CreateUserToRegister(request.Email, request.Name, request.Password);
            var registeredUser = _uow.Users.GetByEmail(request.Email);

            if (await registeredUser is not null)
            {
                await Notify(request, "The user e-mail has already been taken.");

                return CommandResult.Failure();
            }

            user.AddEvent(new UserRegisteredEvent(user.Id, user.Name, user.Email));

            _uow.Users.Create(user);

            return await _uow.Commit();
        }
    }
}
