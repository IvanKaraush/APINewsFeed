using APINewsFeed.BLL.DTO.PostDTOs;
using FluentValidation;

namespace APINewsFeed.BLL.Validators.PostValidators
{
    public class GetPostByUserIdDTOValidator : AbstractValidator<GetPostsByUserIdDTO>
    {
        public GetPostByUserIdDTOValidator() 
        {
            RuleFor(p => p.userId)
                .NotNull()
                .NotEmpty().WithMessage("Поле userId не может быть пустым");
            
            RuleFor(p => p.pageNumber)
                .NotNull()
                .NotEmpty().WithMessage("Поле pageNumber не может быть пустым");

            RuleFor(p => p.pageSize)
                .NotNull()
                .NotEmpty().WithMessage("Поле pageSize не может быть пустым");
        }
    }
}
