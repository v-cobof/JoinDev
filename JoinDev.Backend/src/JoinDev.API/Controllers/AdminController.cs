﻿using JoinDev.Application.Commands;
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
        [Route("theme/create")]
        public async Task<ActionResult> CreateTheme([FromBody] CreateThemeCommand command)
        {
            return await SendCommand(command);
        }

        [HttpPost]
        [Route("theme-category/create")]
        public async Task<ActionResult> CreateThemeCategory([FromBody] CreateThemeCategoryCommand command)
        {
            return await SendCommand(command);
        }

        [HttpPost]
        [Route("link-source/create")]
        public async Task<ActionResult> CreateLinkSource([FromBody] CreateLinkSourceCommand command)
        {
            return await SendCommand(command);
        }
    }
}
