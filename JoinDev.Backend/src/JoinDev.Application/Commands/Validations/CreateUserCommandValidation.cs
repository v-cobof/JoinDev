using FluentValidation;

namespace JoinDev.Application.Commands.Validations
{
    public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidation()
        {
            ValidateName();
            ValidateNickName();
            ValidateEmail();
            ValidatePassword();
        }

        protected void ValidateName()
        {
            RuleFor(c => c.FullName)
                .NotEmpty().WithMessage("Please ensure you have entered the Full Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateNickName()
        {
            RuleFor(c => c.NickName)
                .NotEmpty().WithMessage("Please ensure you have entered the NickName")
                .Length(2, 20).WithMessage("The NickName must have between 2 and 20 characters");
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }

        protected void ValidatePassword()
        {
            RuleFor(c => c.Password)
                .NotEmpty();
        }
    }
}
