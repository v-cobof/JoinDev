using JoinDev.Domain.Core.Communication.Messages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JoinDev.API.Controllers
{
    [Authorize]
    public class ProjectCreatorController : AbstractController
    {
        public ProjectCreatorController(INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
        }

        [HttpGet]
        public ActionResult GetTeste()
        {

            return CustomResponse("teste teste");
        }
    }
}
