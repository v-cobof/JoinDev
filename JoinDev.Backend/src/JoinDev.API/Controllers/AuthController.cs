using JoinDev.API.Security;
using JoinDev.Application;
using JoinDev.Domain.Core.Communication.Messages.Notifications;
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
        private readonly AppSettings _appSettings;

        public AuthController(INotificationHandler<DomainNotification> notifications,
                              IOptions<AppSettings> options) : base(notifications)
        {
            _appSettings = options.Value;
        }

        public async Task<ActionResult> Authenticate([FromBody] string viewModel)
        {
            // busca usuario

            // se nao existir da not found

            // gera o token

            // limpa o campo de senha, e retorna a viewmodel com token
        }

        private async Task<string> GenerateJwt(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email),
                }),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.ValidOn,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiresInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });;

            var encodedToken = tokenHandler.WriteToken(token);

            return encodedToken;
        }
    }
}
