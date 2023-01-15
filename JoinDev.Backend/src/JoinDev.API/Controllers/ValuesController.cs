using JoinDev.Application.Commands;
using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Communication.Messages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JoinDev.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : AbstractController
    {
        private readonly IMediatorHandler _bus;

        public ValuesController(INotificationHandler<DomainNotification> notifications, IMediatorHandler medi) : base(notifications)
        {
            _bus = medi;
        }

        [HttpGet]
        public ActionResult GetTeste()
        {
            var command = new CreateUserCommand("joao", "j.c", "ola sou o", null, "jjsj@hotmail.com", "123456");

            var result = _bus.SendCommand(command);

            return CustomResponse();
        }
    }
}
