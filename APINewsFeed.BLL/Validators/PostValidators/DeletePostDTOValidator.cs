using APINewsFeed.BLL.DTO.PostDTOs;
using FluentValidation;

namespace APINewsFeed.BLL.Validators.PostValidators
{
    public class DeletePostDTOValidator : AbstractValidator<DeletePostDTO>
    {
        public DeletePostDTOValidator()
        {
            RuleFor(i => i.id)
               .NotNull()
               .NotEmpty().WithMessage("Поле id не может быть пустым");
        }
    }
}
