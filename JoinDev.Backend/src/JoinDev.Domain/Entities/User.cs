using JoinDev.Domain.Core.DomainObjects;

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

        // EF - Many to many relationship with Project
        private readonly List<Project> _projectsAsMember;
        public IReadOnlyCollection<Project> ProjectsAsMember => _projectsAsMember;

        // EF - One to many relationship with Project
        private readonly List<Project> _projectsAsCreator;
        public IReadOnlyCollection<Project> ProjectsAsCreator => _projectsAsCreator;

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
