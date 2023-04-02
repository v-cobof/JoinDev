using JoinDev.Application.Queries.ViewModels;
using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Results;
using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;
using JoinDev.Infra.CrossCutting.Security;
using JoinDev.Infra.CrossCutting.Security.Encryption;
using JoinDev.Infra.CrossCutting.Security.Token;
using MediatR;
using Microsoft.Extensions.Options;

namespace JoinDev.Application.Queries.Handlers
{
    public class LoginQueryHandler : BaseQueryHandler<LoginQuery, LoginResponseViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly ITokenService _tokenService;
        private readonly AppSettings _appSettings;

        public LoginQueryHandler(IBusHandler bus,
                                 IUserRepository repository,
                                 IEncryptionService encryptionService,
                                 ITokenService tokenService,
                                 IOptions<AppSettings> options) : base(bus)
        {
            _userRepository = repository;
            _encryptionService = encryptionService;
            _tokenService = tokenService;
            _appSettings = options.Value;
        }

        public async override Task<QueryResult<LoginResponseViewModel>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmail(request.Email);

            if (user is null)
            {
                await Notify(request, "The user was not found");
                return Failure();
            }

            if (!_encryptionService.IsEqual(user.Password, request.Password))
            {
                await Notify(request, "Incorrect user or password");
                return Failure();
            }

            var token = _tokenService.GenerateJwt(user.Email);

            return CreateResponse(user, token);
        }

        private LoginResponseViewModel CreateResponse(User user, string token)
        {
            return new LoginResponseViewModel()
            {
                AccessToken = token,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiresInHours).TotalSeconds,
                UserToken = new UserTokenViewModel()
                {
                    Email = user.Email,
                    Id = user.Id.ToString()
                }
            };
        }
    }
}
