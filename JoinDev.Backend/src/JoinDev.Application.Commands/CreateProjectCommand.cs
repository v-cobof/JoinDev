using JoinDev.Application.Models;
using JoinDev.Domain.Core.Communication.Messages;

namespace JoinDev.Application.Commands
{
    public class CreateProjectCommand : Command
    {
        public string Title { get; set; }
        public string PublicDescription { get; set; }
        public int TotalSpots { get; set; }
        public string CreatorId { get; set; }

        public string RestrictedDescription { get; set; }
        public List<string> ThemesIds { get; set; }
        public List<LinkModel> Links { get; set; }
    }
}
