using FluentValidation.Results;
using JoinDev.Domain.Core.Communication.Messages;

namespace JoinDev.Application.Commands
{
    public abstract class Command : Message, ICommand
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}
