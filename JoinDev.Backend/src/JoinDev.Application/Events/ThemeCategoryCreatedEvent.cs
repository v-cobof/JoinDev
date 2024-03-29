﻿using JoinDev.Domain.Core.Communication.Messages;

namespace JoinDev.Application.Events
{
    public class ThemeCategoryCreatedEvent : Event
    {
        public string Name { get; set; }

        public ThemeCategoryCreatedEvent(Guid Id, string name)
        {
            Name = name;
            AggregateId = Id;
        }
    }
}
