using JoinDev.Application;
using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Core.Communication.Messages.Notifications;
using JoinDev.Domain.Core.Validation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JoinDev.API.Controllers
{
    public abstract class AbstractController : ControllerBase
    {
        protected readonly DomainNotificationHandler _notificationHandler;
        protected readonly IBusHandler _bus;

        public AbstractController(INotificationHandler<DomainNotification> notifications, IBusHandler bus)
        {
            _notificationHandler = notifications as DomainNotificationHandler;
            _bus = bus;
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsOperationValid())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", _notificationHandler.GetErrors().ToArray() }
            }));
        }

        protected async Task<ActionResult> SendCommand(Command command)
        {
            var result = _bus.SendCommand(command);

            return CustomResponse(await result);
        }

        protected bool IsOperationValid()
        {
            return !_notificationHandler.HasNotification();
        }

        protected void ClearErrors()
        {
            _notificationHandler.ClearNotifications();
        }
    }
}
