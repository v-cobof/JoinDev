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
    public class ProjectController : AbstractController
    {
        public ProjectController(
            INotificationHandler<DomainNotification> notifications, 
            IBusHandler bus
        ) : base(notifications, bus)
        {
        }

        [HttpPost]
        [Route("study/create")]
        public async Task<ActionResult> CreateProject([FromBody] CreateStudyProjectCommand command) 
        {
            return await SendCommand(command);
        }

        [HttpPost]
        [Route("job/create")]
        public async Task<ActionResult> CreateProject([FromBody] CreateJobProjectCommand command)
        {
            return await SendCommand(command);
        }
    }
}
