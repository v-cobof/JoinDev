using JoinDev.Domain.Core.DomainObjects;
using JoinDev.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Domain.Entities
{
    public class Project : Entity, IAggregateRoot
    {
        public string Title { get; private set; }
        public string PublicDescription { get; private set; }
        public int AvailableSpots { get; private set; }
        public ProjectCategory Category { get; private set; }
        public ProjectStatus ProjectStatus { get; private set; }

        public ProjectRestrictedInfo ProjectRestrictedInfo { get; private set; }

        private readonly List<string> _participantRequirements;
        public IReadOnlyCollection<string> ParticipantRequirements => _participantRequirements;

        private List<Theme> _themes;
        public IReadOnlyCollection<Theme> Themes => _themes;

        // EF - One to Many relationship with User
        public Guid CreatorId { get; private set; }
        public User Creator { get; private set; }

        // EF - Many to Many relationship with User
        private readonly List<User> _memberUsers;
        public IReadOnlyCollection<User> MemberUsers => _memberUsers;

        // EF - Many to Many relationship with User
        private readonly List<User> _interestedUsers;
        public IReadOnlyCollection<User> InterestedUsers => _interestedUsers;
    }
}
