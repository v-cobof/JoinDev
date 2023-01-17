using FluentValidation;
using JoinDev.Application.Commands.Validations.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Commands.Validations
{
    public class RegisterUserCommandValidation : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidation()
        {
            RuleFor(t => t.FullName).UserNameRule();

            RuleFor(t => t.Email).UserEmailRule();

            RuleFor(t => t.Password).UserPasswordRule();
        }
    }
}
