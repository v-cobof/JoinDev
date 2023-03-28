using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Commands.Validations.Rules
{
    public static class ProjectRules
    {
        public static IRuleBuilderOptions<T, string> ProjectTitleRule<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.NotEmpty()
                .WithMessage("Please ensure you have entered the Project Title")
                .Length(2, 100)
                .WithMessage("The Title must have between 2 and 100 characters");
        }

        public static IRuleBuilderOptions<T, string> ProjectPublicDescriptionRule<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.NotEmpty()
                .WithMessage("Please ensure you have entered the Project Public Description")
                .Length(2, 500)
                .WithMessage("The Public Description must have between 2 and 500 characters");
        }

        public static IRuleBuilderOptions<T, int> ProjectSpotsRule<T>(this IRuleBuilder<T, int> ruleBuilder)
        {
            return ruleBuilder.NotEmpty()
                .WithMessage("Please ensure you have entered the available spots")
                .GreaterThan(0)
                .WithMessage("Please ensure the available spots are greater than zero");
        }

        public static IRuleBuilderOptions<T, Guid> ProjectCreatorIdRule<T>(this IRuleBuilder<T, Guid> ruleBuilder)
        {
            return ruleBuilder.NotEmpty()
                .WithMessage("Please ensure the project has a creator");
        }

        public static IRuleBuilderOptions<T, string> ProjectRestrictedDescriptionRule<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.NotEmpty()
                .WithMessage("Please ensure you have entered the Project Restricted Description")
                .Length(2, 100)
                .WithMessage("The Restricted Description must have between 2 and 100 characters");
        }

        public static IRuleBuilderOptions<T, IEnumerable<Guid>> ProjectThemesIdsRule<T>(this IRuleBuilder<T, IEnumerable<Guid>> ruleBuilder)
        {
            return ruleBuilder.NotEmpty()
                .WithMessage("Please ensure you have entered the Project Themes");
        }
    }
}
