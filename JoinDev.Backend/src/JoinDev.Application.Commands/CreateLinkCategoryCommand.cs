using JoinDev.Domain.Core.Communication.Messages;

namespace JoinDev.Application.Commands
{
    public class CreateLinkCategoryCommand : Command
    {
        public string Name { get; set; }
    }
}
