using JoinDev.API.Security;
using JoinDev.API.Security.Encryption;
using JoinDev.API.Security.Token;
using JoinDev.API.ViewModels;
using JoinDev.Application.Commands;
using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Communication.Messages.Notifications;
using JoinDev.Domain.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace JoinDev.API.Controllers
{
    public class AuthController : AbstractController
    {
        private readonly ITokenService _tokenService;
        private readonly IEncryptionService _encryptionService;
        private readonly IUserRepository _userRepository;
        private readonly AppSettings _appSettings;

        public AuthController(INotificationHandler<DomainNotification> notifications,
                              ITokenService tokenService,
                              IEncryptionService encryptionService,
                              IUserRepository userRepository,
                              IOptions<AppSettings> options,
                              IBusHandler bus
        ) : base(notifications, bus)
        {
            _encryptionService = encryptionService;
            _tokenService = tokenService;
            _userRepository = userRepository;
            _appSettings = options.Value;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserCommand command)
        {
            command.Password = _encryptionService.Encrypt(command.Password);

            var result = _bus.SendCommand(command);

            return CustomResponse(await result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginResponseViewModel>> Login([FromBody] LoginUserViewModel viewModel)
        {
            var user = await _userRepository.GetByEmail(viewModel.Email);

            if (user is null) return NotFound();

            if(!_encryptionService.IsEqual(user.Password, viewModel.Password))
            {
                return Forbid();
            }

            var email = user.Email;
            var token = _tokenService.GenerateJwt(email);

            return new LoginResponseViewModel()
            {
                AccessToken = token,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiresInHours).TotalSeconds,
                UserToken = new UserTokenViewModel()
                {
                    Email = email,
                    Id = user.Id.ToString()
                }
            };
        }
    }
}
