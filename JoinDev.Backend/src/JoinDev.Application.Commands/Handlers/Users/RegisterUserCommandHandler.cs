using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Validation.Results;
using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;
using JoinDev.Application.Events;
using JoinDev.Infra.CrossCutting.Security.Encryption;

namespace JoinDev.Application.Commands.Handlers.Users
{
    public class RegisterUserCommandHandler : BaseCommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptionService _encryptionService;

        public RegisterUserCommandHandler(IUserRepository repository,
                                          IBusHandler bus,
                                          IEncryptionService encryptionService) : base(bus)
        {
            _userRepository = repository;
            _encryptionService = encryptionService;
        }

        public async override Task<CommandResult> Execute(RegisterUserCommand request)
        {
            request.Password = _encryptionService.Encrypt(request.Password);

            var registeredUser = _userRepository.GetByEmail(request.Email);

            if (await registeredUser is not null)
            {
                await Notify(request, "The user e-mail has already been taken.");
                return CommandResult.Failure();
            }

            var user = User.Factory.CreateUserToRegister(request.Email, request.Name, request.Password);
            user.AddEvent(new UserRegisteredEvent(user));

            _userRepository.Create(user);

            return await _userRepository.UnitOfWork.Commit();
        }
    }
}
