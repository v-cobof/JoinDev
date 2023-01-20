using JoinDev.Domain.Core.DomainObjects;
using JoinDev.Domain.ValueObjects;

namespace JoinDev.Domain.Entities
{
    public class User : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }


        private List<Link> _links;
        public IReadOnlyCollection<Link> Links => _links;


        private readonly List<Project> _projectsAsMember;
        public IReadOnlyCollection<Project> ProjectsAsMember => _projectsAsMember;


        private readonly List<Project> _projectsAsInterested;
        public IReadOnlyCollection<Project> ProjectsAsInterested => _projectsAsInterested;


        private readonly List<Project> _projectsAsCreator;
        public IReadOnlyCollection<Project> ProjectsAsCreator => _projectsAsCreator;


        public User(string name, string description, List<Link> links, string email, string password)
        {
            Name = name;            
            Description = description;
            _links = links;
            Email = email;
            Password = password;
        }

        // EF
        protected User() { }     
        
        public static class UserFactory
        {
            public static User CreateUserToRegister(string email, string name, string password)
            {
                return new User()
                {
                    Name = name,
                    Password = password,
                    Email = email
                };
            }
        }
    }
}
