﻿using JoinDev.Application.Data;
using JoinDev.Application.Models;
using MassTransit;

namespace JoinDev.Application.Events.Handlers
{
    public class ProjectCreatedEventHandler : BaseDataReplicationEventHandler<ProjectCreatedEvent, ProjectReadModel>
    {
        public ProjectCreatedEventHandler(IReplicationRepository<ProjectReadModel> repository) : base(repository)
        {
        }

        public override Task Consume(ConsumeContext<ProjectCreatedEvent> context)
        {
            return _repository.Create(context.Message.ProjectModel);
        }
    }
}
