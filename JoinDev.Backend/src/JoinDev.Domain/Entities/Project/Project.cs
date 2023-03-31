using JoinDev.Domain.Core.DomainObjects;
using JoinDev.Domain.Core.Validation;
using JoinDev.Domain.Enums;

namespace JoinDev.Domain.Entities
{
    public abstract class Project : Entity, IAggregateRoot
    {
        public string Title { get; private set; }
        public string PublicDescription { get; private set; }
        public int TotalSpots { get; private set; }
        public ProjectStatus ProjectStatus { get; private set; }
        public Guid CreatorId { get; private set; }
        public ProjectRestrictedInfo ProjectRestrictedInfo { get; private set; }
        public int AvailableSpots => TotalSpots - _memberUsers.Count;


        public User Creator { get; private set; }


        private List<Theme> _themes;
        public IReadOnlyCollection<Theme> Themes => _themes;


        private readonly List<User> _memberUsers;
        public IReadOnlyCollection<User> MemberUsers => _memberUsers;


        private readonly List<User> _interestedUsers;
        public IReadOnlyCollection<User> InterestedUsers => _interestedUsers;


        public Project(string title, string publicDescription, int totalSpots, List<Theme> themes, Guid creatorId)
        {
            Title = title;
            PublicDescription = publicDescription;
            TotalSpots = totalSpots;
            _themes = themes;
            CreatorId = creatorId;

            // V1 behaviour
            ProjectStatus = ProjectStatus.Started;

            _memberUsers = new List<User>();
            _interestedUsers = new List<User>();
        }

        protected Project()
        {
            _memberUsers = new List<User>();
            _interestedUsers = new List<User>();
        }

        public void SetProjectRestrictedInfo(ProjectRestrictedInfo projectRestrictedInfo)
        {
            ProjectRestrictedInfo = projectRestrictedInfo;
        }

        public void AddInterestedUser(User user)
        {
            _interestedUsers.Add(user);
        }

        public void AddMemberFromInterestedUsers(Guid userId)
        {
            if (AvailableSpots == 0)
                throw new DomainException("There are no more available spots in the project.");

            var user = _interestedUsers.SingleOrDefault(t => t.Id == userId);

            if (user == default) 
                throw new DomainException("The user did not declare interest in the project.");

            _interestedUsers.Remove(user);

            _memberUsers.Add(user);
        }

        protected virtual void Validate()
        {
            Title.ShouldNotBeEmpty(nameof(Title));
            PublicDescription.ShouldNotBeEmpty(nameof(PublicDescription));
            TotalSpots.ShouldNotBeLessThanNorEqualTo(0, nameof(TotalSpots));
            CreatorId.ShouldNotBeEqualTo(Guid.Empty, nameof(CreatorId));
        }
    }
}
