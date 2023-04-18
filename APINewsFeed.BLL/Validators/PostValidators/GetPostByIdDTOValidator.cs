using APINewsFeed.BLL.DTO.PostDTOs;
using FluentValidation;

namespace APINewsFeed.BLL.Validators.PostValidators
{
    public class GetPostByIdDTOValidator : AbstractValidator<GetPostByIdDTO>
    {
        public GetPostByIdDTOValidator()
        {
            RuleFor(p => p.id)
                .NotNull()
                .NotEmpty().WithMessage("Поле id не может быть пустым");
        }
    }
}
