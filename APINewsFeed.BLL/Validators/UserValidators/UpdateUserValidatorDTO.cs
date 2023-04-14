using APINewsFeed.BLL.DTO.UserDTOs;
using FluentValidation;

namespace APINewsFeed.BLL.Validators.UserValidators
{
    public class UpdateUserValidatorDTO : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserValidatorDTO()
        {
            RuleFor(i => i.id)
               .NotNull()
               .NotEmpty().WithMessage("Поле id не может быть пустым");

            RuleFor(l => l.email)
                .EmailAddress();
        }
    }
}
