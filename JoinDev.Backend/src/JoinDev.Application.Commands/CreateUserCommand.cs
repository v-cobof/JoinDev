using JoinDev.Application.Commands.Validations;
using JoinDev.Domain.Core.Communication.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Commands
{
    public class CreateUserCommand : Command, IQueueable
    {
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public CreateUserCommand(string fullName, string nickName, string description, string image, string email, string password)
        {
            FullName = fullName;
            NickName = nickName;
            Description = description;
            Image = image;
            Email = email;
            Password = password;
        }

        public CreateUserCommand() { }
    }
}
