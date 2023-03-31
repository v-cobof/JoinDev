using JoinDev.Application.Models;
using JoinDev.Domain.Core.Communication.Messages;

namespace JoinDev.Application.Commands
{
    public class FillProjectRestrictedInfoCommand : Command
    {
        public string Description { get; set; }
        public List<LinkModel> Links { get; set; }
        public Guid ProjectId { get; private set; }
    }
}
