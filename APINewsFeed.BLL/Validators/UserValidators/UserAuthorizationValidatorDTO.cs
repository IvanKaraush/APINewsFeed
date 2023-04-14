using APINewsFeed.BLL.DTO.UserDTOs;
using FluentValidation;

namespace APINewsFeed.BLL.Validators.UserValidators
{
    public class UserAuthorizationValidatorDTO : AbstractValidator<UserAuthorizationDTO>
    {
        public UserAuthorizationValidatorDTO()
        {
            RuleFor(n => n.name)
                .NotNull()
                .NotEmpty().WithMessage("Поле name не может быть пустым");

            RuleFor(n => n.password)
                .NotNull()
                .NotEmpty().WithMessage("Поле password не может быть пустым");

        }
    }
}
