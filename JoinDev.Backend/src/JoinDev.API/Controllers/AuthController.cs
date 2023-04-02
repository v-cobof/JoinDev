using JoinDev.Application.Commands;
using JoinDev.Application.Queries;
using JoinDev.Application.Queries.ViewModels;
using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Communication.Messages.Notifications;
using JoinDev.Domain.Data;
using JoinDev.Infra.CrossCutting.Security;
using JoinDev.Infra.CrossCutting.Security.Encryption;
using JoinDev.Infra.CrossCutting.Security.Token;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace JoinDev.API.Controllers
{
    public class AuthController : AbstractController
    {

        public AuthController(INotificationHandler<DomainNotification> notifications, IBusHandler bus) : base(notifications, bus)
        {
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserCommand command)
        {
            return await SendCommand(command);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginResponseViewModel>> Login([FromBody] LoginQuery query)
        {
            var result = await SendQuery(query);

            return result;

            /*
            var user = await _userRepository.GetByEmail(viewModel.Email);

            if (user is null) return NotFound();

            if (!_encryptionService.IsEqual(user.Password, viewModel.Password))
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
            };*/
        }
    }
}
