using JoinDev.Application.Commands;
using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Communication.Messages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JoinDev.API.Controllers
{
    [Authorize]
    [Route("admin")]
    public class AdminController : AbstractController
    {
        public AdminController(INotificationHandler<DomainNotification> notifications, IBusHandler bus) : base(notifications, bus)
        {
        }

        [HttpPost]
        [Route("create-theme")]
        public async Task<ActionResult> CreateTheme([FromBody] CreateThemeCommand command)
        {
            var result = _bus.SendCommand(command);

            return CustomResponse(await result);
        }

        [HttpPost]
        [Route("create-theme-category")]
        public async Task<ActionResult> CreateThemeCategory([FromBody] CreateThemeCategoryCommand command)
        {
            var result = _bus.SendCommand(command);

            return CustomResponse(await result);
        }
    }
}
