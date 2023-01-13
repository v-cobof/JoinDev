﻿using JoinDev.Domain.Core.Validation.Results;
using MediatR;

namespace JoinDev.Domain.Core.Communication.Messages
{
    public abstract class Command : Message, IRequest<CommandResult>
    {
        public CommandResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}