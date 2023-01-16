using JoinDev.API.Security;
using JoinDev.API.Security.Encryption;
using JoinDev.API.Security.Token;
using JoinDev.API.ViewModels;
using JoinDev.Application;
using JoinDev.Domain.Core.Communication.Messages.Notifications;
using JoinDev.Domain.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JoinDev.API.Controllers
{
    public class AuthController : AbstractController
    {
        private readonly ITokenService _tokenService;
        private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _uow;
        private readonly AppSettings _appSettings;

        public AuthController(INotificationHandler<DomainNotification> notifications,
                              ITokenService tokenService,
                              IEncryptionService encryptionService,
                              IUnitOfWork uow,
                              IOptions<AppSettings> options
        ) : base(notifications)
        {
            _encryptionService = encryptionService;
            _tokenService = tokenService;   
            _uow = uow;
            _appSettings = options.Value;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginResponseViewModel>> Login([FromBody] LoginUserViewModel viewModel)
        {
            var user = await _uow.Users.GetByEmail(viewModel.Email);

            if (user is null) return NotFound();

            if(!_encryptionService.IsEqual(user.UserSecretInfo.Password, viewModel.Password))
            {
                return Forbid();
            }

            var email = user.UserSecretInfo.Email;
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
