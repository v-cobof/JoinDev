using JoinDev.Domain.Core.Communication.Messages;

namespace JoinDev.Application.Commands
{
    public class RegisterUserCommand : Command, IQueueable
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
