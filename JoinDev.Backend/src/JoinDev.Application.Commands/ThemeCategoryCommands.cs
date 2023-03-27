using JoinDev.Domain.Core.Communication.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Commands
{
    public class CreateThemeCategoryCommand : Command
    {
        public string Name { get; set; }
    }
}
