using FluentValidation;
using JoinDev.Application.Commands.Validations.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Commands.Validations
{
    public class CreateStudyProjectCommandValidation : AbstractValidator<CreateStudyProjectCommand>
    {
        public CreateStudyProjectCommandValidation()
        {
            RuleFor(c => c.Title).ProjectTitleRule();
            RuleFor(c => c.PublicDescription).ProjectPublicDescriptionRule();
            RuleFor(c => c.TotalSpots).ProjectSpotsRule();
            RuleFor(c => c.CreatorId).ProjectCreatorIdRule();
            RuleFor(c => c.ThemesIds).ProjectThemesIdsRule();

            RuleFor(c => c.StudyProjectLevel).NotEmpty();
        }
    }

    public class CreateJobProjectCommandValidation : AbstractValidator<CreateJobProjectCommand>
    {
        public CreateJobProjectCommandValidation()
        {
            RuleFor(c => c.Title).ProjectTitleRule();
            RuleFor(c => c.PublicDescription).ProjectPublicDescriptionRule();
            RuleFor(c => c.TotalSpots).ProjectSpotsRule();
            RuleFor(c => c.CreatorId).ProjectCreatorIdRule();
            RuleFor(c => c.ThemesIds).ProjectThemesIdsRule();

            RuleFor(c => c.JobProjectLevel).NotEmpty();
            RuleFor(c => c.MemberPayment).NotEmpty().WithMessage("Please ensure you have entered the Member Payment value.");
        }
    }
}
