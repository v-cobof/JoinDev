using JoinDev.Application;
using JoinDev.Domain.Core.Communication.Messages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JoinDev.API.Controllers
{
    public abstract class AbstractController : ControllerBase
    {
        private readonly DomainNotificationHandler _notificationHandler;

        public AbstractController(INotificationHandler<DomainNotification> notifications)
        {
            _notificationHandler = notifications as DomainNotificationHandler;
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
