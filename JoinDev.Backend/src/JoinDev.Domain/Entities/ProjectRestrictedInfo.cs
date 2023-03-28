using JoinDev.Domain.Core.DomainObjects;
using JoinDev.Domain.Core.Validation;
using JoinDev.Domain.ValueObjects;
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
        public IReadOnlyCollection<Link> Links => _links;
        public Guid ProjectId { get; private set; }
        public Project Project { get; private set; }

        private List<Link> _links;

        public ProjectRestrictedInfo(string description, Guid projectId, List<Link> links)
        {
            Description = description;
            ProjectId = projectId;
            _links = links;

            Validate();
        }

        protected ProjectRestrictedInfo() { }

        public void Validate()
        {
            Description.ShouldNotBeEmpty(nameof(Description));
            ProjectId.ShouldNotBeEqualTo(Guid.Empty, nameof(ProjectId));
            Links.ShouldNotBeEmpty(nameof(Links));
        }
    }
}
