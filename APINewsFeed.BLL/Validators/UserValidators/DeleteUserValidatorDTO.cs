using APINewsFeed.BLL.DTO.UserDTOs;
using FluentValidation;

namespace APINewsFeed.BLL.Validators.UserValidators
{
    public class DeleteUserValidatorDTO : AbstractValidator<DeleteUserDTO>
    {
        public DeleteUserValidatorDTO()
        {
            RuleFor(i => i.id)
                .NotNull()
                .NotEmpty().WithMessage("Поле id не может быть пустым");
        }
    }
}
