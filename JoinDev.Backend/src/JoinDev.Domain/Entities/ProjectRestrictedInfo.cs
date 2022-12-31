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
        public Guid ProjectId { get; private set; }
        public Project Project { get; private set; }

        // EF - 1:N
        private List<ProjectLink> _links;
        public IReadOnlyCollection<ProjectLink> Links => _links;

        public ProjectRestrictedInfo(string description, Guid projectId, List<ProjectLink> links)
        {
            Description = description;
            ProjectId = projectId;
            _links = links;
        }

        protected ProjectRestrictedInfo() { }
    }
}
