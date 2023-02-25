using JoinDev.Domain.Core.Communication.Messages;

namespace JoinDev.Application.Commands
{
    public class CreateLinkSourceCommand : Command
    {
        public string Name { get; set; }
    }
}
