using JoinDev.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Domain.Entities
{
    public class UserLink : Link
    {
        // EF
        public User User { get; private set; }
        public Guid UserId { get; private set; }

        public UserLink(string name, string url, LinkSource linkSource) : base(name, url, linkSource)
        {
        }
    }
}
