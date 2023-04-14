using APINewsFeed.BLL.DTO.UserDTOs;
using FluentValidation;

namespace APINewsFeed.BLL.Validators.UserValidators
{
    public class GetUserValidatorDTO : AbstractValidator<GetUserDTO>
    {
        public GetUserValidatorDTO()
        {
            RuleFor(i => i.id)
               .NotNull()
               .NotEmpty().WithMessage("Поле id не может быть пустым");
        }
    }
}
