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

        public CommandResult(bool success)
        {
            Success = success;
        }

        public static CommandResult Successful()
        {
            return new CommandResult(true);
        }

        public static CommandResult Failure()
        {
            return new CommandResult(false);
        }

        public static implicit operator CommandResult(bool success) => new(success);
    }
}
