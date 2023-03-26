using JoinDev.API.Security;
using JoinDev.Application.Commands;
using JoinDev.Application.Mappers;
using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Communication.Messages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JoinDev.API.Controllers
{
    [Authorize]
    [Route("projects")]
    public class ProjectCreatorController : AbstractController
    {
        public ProjectCreatorController(
            INotificationHandler<DomainNotification> notifications, 
            IBusHandler bus
        ) : base(notifications, bus)
        {
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateProject([FromBody] CreateProjectCommand command) 
        {
            command.Links.SetAsUserLinks();
            
            return await SendCommand(command);
        }
    }
}
