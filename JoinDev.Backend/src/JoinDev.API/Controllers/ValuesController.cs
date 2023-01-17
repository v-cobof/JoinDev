using JoinDev.Application.Commands;
using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Communication.Messages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JoinDev.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ValuesController : AbstractController
    {
        private readonly IMediatorHandler _bus;

        public ValuesController(INotificationHandler<DomainNotification> notifications, IMediatorHandler medi) : base(notifications)
        {
            _bus = medi;
        }

        [HttpGet]
        [Authorize(Roles = "")]
        public ActionResult GetTeste()
        {
            var command = new RegisterUserCommand("joao", "jjsj@hotmail.com", "123456");

            var result = _bus.SendCommand(command);

            return CustomResponse();
        }
    }
}
