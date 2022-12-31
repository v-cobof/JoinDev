using JoinDev.Domain.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Domain.Entities
{
    public class ProjectRestrictedInfo : Entity
    {
        public string Description { get; private set; }

        public string Links { get; private set; }
    }
}
