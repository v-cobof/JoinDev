using JoinDev.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Domain.Entities
{
    public class ProjectLink : Link
    {
        // EF
        public ProjectRestrictedInfo ProjectRestrictedInfo { get; private set; }

        public ProjectLink(string name, string url, LinkSource linkSource) : base(name, url, linkSource)
        {
        }
    }
}
