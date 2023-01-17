using JoinDev.Domain.Core.Communication.Messages;

namespace JoinDev.Application.Commands
{
    public class RegisterUserCommand : Command
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RegisterUserCommand(string fullName, string email, string password)
        {
            FullName = fullName;
            Email = email;
            Password = password;
        }

        public RegisterUserCommand() { }

    }
}
