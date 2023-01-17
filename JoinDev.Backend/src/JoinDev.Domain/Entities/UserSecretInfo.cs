using JoinDev.Domain.Core.DomainObjects;

namespace JoinDev.Domain.Entities
{
    public class UserSecretInfo : Entity
    {
        public Guid UserId { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User User { get; private set; }

        public UserSecretInfo(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
