using APINewsFeed.BLL.DTO.PostDTOs;
using FluentValidation;

namespace APINewsFeed.BLL.Validators.PostValidators
{
    public class FilterPostDTOValidator : AbstractValidator<FilterPostDTO>
    {
        public FilterPostDTOValidator()
        {
            RuleFor(p => p.pageNumber)
                .NotNull()
                .NotEmpty().WithMessage("Поле pageNumber не может быть пустым");
            
            RuleFor(p => p.pageSize)
                .NotNull()
                .NotEmpty().WithMessage("Поле pageSize не может быть пустым");
        }
    }
}
