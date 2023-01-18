using JoinDev.Domain.Core.Communication.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Commands
{
    public class CreateProjectCommand : Command
    {
        public string Title { get; private set; }
        public string PublicDescription { get; private set; }
        public int TotalSpots { get; private set; }
        public Guid CreatorId { get; private set; }
    }
}
