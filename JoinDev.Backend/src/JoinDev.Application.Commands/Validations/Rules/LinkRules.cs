using FluentValidation;
using JoinDev.Application.Models;
using JoinDev.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Commands.Validations.Rules
{
    public static class LinkRules
    {
        public static IRuleBuilderOptions<T, string> LinkNameRule<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.NotEmpty()
                .WithMessage("Please ensure you have entered the Link Name")
                .Length(2, 100)
                .WithMessage("The Link name must have between 2 and 100 characters");
        }

        public static IRuleBuilderOptions<T, string> LinkUrlRule<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.NotEmpty()
                .WithMessage("Please ensure you have entered the Link Name")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .WithMessage("Please ensure the link is valid");
        }

        public static IRuleBuilderOptions<T, Guid> LinkSourceRule<T>(this IRuleBuilder<T, Guid> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                .NotEqual(Guid.Empty)
                .WithMessage("Please ensure the link source is valid");
        }

        public static IRuleBuilderOptions<LinkType?, string> LinkTypeRule<T>(this IRuleBuilder<LinkType?, string> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                .WithMessage("Please ensure the link type is valid");
        }
    }
}
