using JoinDev.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Domain.Entities
{
    public class JobProject : Project
    {
        public JobProjectLevel JobProjectLevel { get; private set; }

        public decimal MemberPayment { get; private set; }

        public JobProject(string title, string publicDescription, int totalSpots, List<Theme> themes, Guid creatorId, JobProjectLevel level, decimal memberPayment) 
            : base(title, publicDescription, totalSpots, themes, creatorId)
        {
            JobProjectLevel = level;
            MemberPayment = memberPayment;
        }

        protected JobProject() : base() { }
    }
}
