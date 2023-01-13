using FluentValidation.Results;
using JoinDev.Domain.Core.Validation.Results;

namespace JoinDev.Application.Mappers
{
    public static class CommandResultMapper
    {
        public static CommandResult ToCommandResult(this ValidationResult validationResult)
        {
            return new CommandResult()
            {
                Success = validationResult.IsValid,
                Errors = validationResult.Errors.Select(t => new ValidationError(t.ErrorMessage))
            };
        }

        public static Task<CommandResult> ToCommandResultTask(this ValidationResult validationResult)
        {
            return Task.FromResult(validationResult.ToCommandResult());
        }
    }
}
