﻿using FluentValidation;
using JoinDev.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Commands.Validations.Rules
{
    public static class ThemeRules
    {
        public static IRuleBuilderOptions<T, string> ThemeNameRule<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.NotEmpty()
                .WithMessage("Please ensure you have entered the Name of the Theme")
                .Length(2, 100)
                .WithMessage("The Name must have between 2 and 100 characters");
        }

        public static IRuleBuilderOptions<T, ThemeCategory?> ThemeCategoryRule<T>(this IRuleBuilder<T, ThemeCategory?> ruleBuilder)
        {
            return ruleBuilder.NotNull()
                .WithMessage("Please ensure you have entered a theme Category");
        }
    }
}
