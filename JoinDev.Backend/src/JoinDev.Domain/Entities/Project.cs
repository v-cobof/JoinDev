using JoinDev.Domain.Core.DomainObjects;
using JoinDev.Domain.Enums;

namespace JoinDev.Domain.Entities
{
    public class Project : Entity, IAggregateRoot
    {
        public string Title { get; private set; }
        public string PublicDescription { get; private set; }
        public int TotalSpots { get; private set; }
        public int AvailableSpots => TotalSpots - _memberUsers.Count;
        public ProjectCategory Category { get; private set; }
        public ProjectStatus ProjectStatus { get; private set; }
        //public DateTime StartDate { get; private set; }

        // EF - N:N - Theme
        private List<Theme> _themes;
        public IReadOnlyCollection<Theme> Themes => _themes;

        // EF - 1:1 - ProjectRestrictedInfo
        public ProjectRestrictedInfo ProjectRestrictedInfo { get; private set; }

        // EF - 1:N - User
        public Guid CreatorId { get; private set; }
        public User Creator { get; private set; }

        // EF - N:N - User
        private readonly List<User> _memberUsers;
        public IReadOnlyCollection<User> MemberUsers => _memberUsers;

        // EF - N:N - User
        private readonly List<User> _interestedUsers;
        public IReadOnlyCollection<User> InterestedUsers => _interestedUsers;

        public Project(string title, string publicDescription, int totalSpots, ProjectCategory category, List<Theme> themes, Guid creatorId)
        {
            Title = title;
            PublicDescription = publicDescription;
            TotalSpots = totalSpots;
            Category = category;
            _themes = themes;
            CreatorId = creatorId;
            ProjectStatus = ProjectStatus.Preparation;

            _memberUsers = new List<User>();
            _interestedUsers = new List<User>();
        }

        protected Project()
        {
            _memberUsers = new List<User>();
            _interestedUsers = new List<User>();
        }

        public void AddProjectRestrictedInfo(ProjectRestrictedInfo projectRestrictedInfo)
        {
            ProjectRestrictedInfo = projectRestrictedInfo;
        }

        
    }
}
