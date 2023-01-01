using JoinDev.Domain.Core.DomainObjects;

namespace JoinDev.Domain.Entities
{
    public class User : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Description { get; private set; }

        // EF - 1:N
        private List<UserLink> _links;
        public IReadOnlyCollection<UserLink> Links => _links;

        // EF - N:N - Project
        private readonly List<Project> _projectsAsMember;
        public IReadOnlyCollection<Project> ProjectsAsMember => _projectsAsMember;

        // EF - N:N - Project
        private readonly List<Project> _projectsAsInterested;
        public IReadOnlyCollection<Project> ProjectsAsInterested => _projectsAsInterested;

        // EF - 1:N - Project
        private readonly List<Project> _projectsAsCreator;
        public IReadOnlyCollection<Project> ProjectsAsCreator => _projectsAsCreator;

        public User(string name, string email, string phoneNumber, string description, List<UserLink> links)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Description = description;
            _links = links;
        }

        // EF
        protected User() { }     
        
    }
}
