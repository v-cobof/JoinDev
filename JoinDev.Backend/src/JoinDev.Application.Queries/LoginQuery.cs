using JoinDev.Application.Queries.ViewModels;
using JoinDev.Domain.Core.Communication.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Queries
{
    public class LoginQuery : Query<LoginResponseViewModel>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
