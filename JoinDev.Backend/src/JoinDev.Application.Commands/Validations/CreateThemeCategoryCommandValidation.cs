using FluentValidation;
using JoinDev.Application.Commands.Validations.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Commands.Validations
{
    public class CreateThemeCategoryCommandValidation : AbstractValidator<CreateThemeCategoryCommand>
    {
        public CreateThemeCategoryCommandValidation()
        {
            RuleFor(c => c.Name).NameRule();
        }
    }
}
