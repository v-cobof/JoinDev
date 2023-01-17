using JoinDev.Domain.Core.DomainObjects;

namespace JoinDev.Domain.Entities
{
    public class User : Entity, IAggregateRoot
    {
        public string FullName { get; private set; }
        public string NickName { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public UserSecretInfo UserSecretInfo { get; private set; }

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

        public User(string fullName, string nickName, string description, List<UserLink> links, UserSecretInfo userSecretInfo)
        {
            FullName = fullName;
            NickName = nickName;            
            Description = description;
            _links = links;
            UserSecretInfo = userSecretInfo;
        }

        // EF
        protected User() { }     
        
        public static class UserFactory
        {
            public static User CreateUserToRegister(string email, string name, string password)
            {
                return new User()
                {
                    FullName = name,
                    UserSecretInfo = new UserSecretInfo(email, password)
                };
            }
        }
    }
}
