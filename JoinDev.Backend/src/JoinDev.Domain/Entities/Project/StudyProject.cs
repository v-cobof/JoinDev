using JoinDev.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Domain.Entities
{
    public class StudyProject : Project
    {
        public StudyProjectLevel StudyProjectLevel { get; private set; }

        public StudyProject(string title, string publicDescription, int totalSpots, List<Theme> themes, Guid creatorId, StudyProjectLevel level)
            : base(title, publicDescription, totalSpots, themes, creatorId)
        {
            StudyProjectLevel = level;
        }

        protected StudyProject() : base() { }

        public new void Validate()
        {
            base.Validate();
        }
    }
}
