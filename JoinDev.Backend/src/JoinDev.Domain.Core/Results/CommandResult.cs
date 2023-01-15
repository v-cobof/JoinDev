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

        public static CommandResult Successful()
        {
            return new CommandResult() { Success = true };
        }

        public static CommandResult Failure()
        {
            return new CommandResult() { Success = false };
        }
    }
}
