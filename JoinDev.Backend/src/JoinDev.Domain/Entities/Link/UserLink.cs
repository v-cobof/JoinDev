using JoinDev.Domain.Enums;

namespace JoinDev.Domain.Entities
{
    public class UserLink : Link
    {
        // EF
        public User User { get; private set; }
        public Guid UserId { get; private set; }

        public UserLink(string name, string url, LinkSource linkSource) : base(name, url, linkSource)
        {
            Validate();
        }

        public new void Validate()
        {
            base.Validate();
        }
    }
}
