using APINewsFeed.BLL.DTO.CommentDTOs;
using FluentValidation;

namespace APINewsFeed.BLL.Validators.CommentValidators
{
    public class GetCommentsDTOValidator : AbstractValidator<GetCommentsDTO>
    {
        public GetCommentsDTOValidator()
        {
            RuleFor(c => c.pageNumber)
                .NotNull()
                .NotEmpty().WithMessage("Поле pageNumber не может быть пустым");

            RuleFor(c => c.postId)
                .NotNull()
                .NotEmpty().WithMessage("Поле postId не может быть пустым");
        }
    }
}
