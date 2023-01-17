using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Commands.Validations.Rules
{
    public static class UserRules
    {
        public static IRuleBuilderOptions<T, string> UserNameRule<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.NotEmpty()
                .WithMessage("Please ensure you have entered the Name")
                .Length(2, 150)
                .WithMessage("The Name must have between 2 and 150 characters");
        }

        public static IRuleBuilderOptions<T, string> UserEmailRule<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                .EmailAddress();
        }

        public static IRuleBuilderOptions<T, string> UserPasswordRule<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty();
        }
    }
}
