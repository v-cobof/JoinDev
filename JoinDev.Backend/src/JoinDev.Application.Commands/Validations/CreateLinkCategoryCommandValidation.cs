using FluentValidation;
using JoinDev.Application.Commands.Validations.Rules;

namespace JoinDev.Application.Commands.Validations
{
    public class CreateLinkCategoryCommandValidation : AbstractValidator<CreateLinkSourceCommand>
    {
        public CreateLinkCategoryCommandValidation()
        {
            RuleFor(c => c.Name).NameRule();
        }
    }
}
