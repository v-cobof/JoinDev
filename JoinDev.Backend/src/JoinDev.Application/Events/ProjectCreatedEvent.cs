using JoinDev.Application.Models;
using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Core.DomainObjects;
using JoinDev.Domain.Entities;

namespace JoinDev.Application.Events
{
    public class ProjectCreatedEvent : Event
    {
        public ProjectModel ProjectModel { get; set; }

        public ProjectCreatedEvent(Project project)
        {
            ProjectModel = project;
        }
    }
}
