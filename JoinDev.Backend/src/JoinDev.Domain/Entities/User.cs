using JoinDev.Domain.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Domain.Entities
{
    public class User : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public string GitHubProfile { get; private set; }
      
        private readonly List<Project> _projectsParticipating;
        public IReadOnlyCollection<Project> ProjectsParticipating => _projectsParticipating;       

        private readonly List<Project> _projectsCreated;
        public IReadOnlyCollection<Project> ProjectsCreated => _projectsCreated;

        public User(string name, string email, string phoneNumber, string description, string image, string gitHubProfile)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Description = description;
            Image = image;
            GitHubProfile = gitHubProfile;
        }

        // EF
        protected User() { }
    }
}
