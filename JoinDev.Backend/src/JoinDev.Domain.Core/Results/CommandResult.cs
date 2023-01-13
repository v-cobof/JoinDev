using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Domain.Core.Validation.Results
{
    public class CommandResult
    {
        public bool Success { get; set; }

        public IEnumerable<ValidationError> Errors { get; set; }

        public CommandResult() 
        {
            Errors = new List<ValidationError>();
        }

        public static Task<CommandResult> Successful()
        {
            return Task.FromResult(new CommandResult() { Success = true });
        }

        public bool IsValid()
        {
            return !Errors.Any();
        }
    }
}
