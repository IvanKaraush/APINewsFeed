using APINewsFeed.BLL.DTO.UserDTOs;
using FluentValidation;


namespace APINewsFeed.BLL.Validators.UserValidators
{
    public class UserRegistrationsValidatorDTO : AbstractValidator<UserRegistrationDTO>
    {
        public UserRegistrationsValidatorDTO()
        {
            RuleFor(n => n.name)
                .NotNull()
                .NotEmpty().WithMessage("Поле name не может быть пустым");

            RuleFor(l => l.email)
                .NotNull()
                .NotEmpty().WithMessage("Поле email не может быть пустым")
                .EmailAddress();

            RuleFor(n => n.password)
                .NotNull()
                .NotEmpty().WithMessage("Поле password не может быть пустым");

        }
    }
}
