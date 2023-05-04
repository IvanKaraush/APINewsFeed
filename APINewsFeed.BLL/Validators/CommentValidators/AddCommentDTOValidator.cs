using APINewsFeed.BLL.DTO.CommentDTOs;
using FluentValidation;

namespace APINewsFeed.BLL.Validators.CommentValidators
{
    public class AddCommentDTOValidator : AbstractValidator<AddCommentDTO>
    {
        public AddCommentDTOValidator()
        {
            RuleFor(c => c.userId)
                .NotNull()
                .NotEmpty().WithMessage("Поле userId не может быть пустым");

            RuleFor(c => c.postId)
                .NotNull()
                .NotEmpty().WithMessage("Поле postId не может быть пустым");

            RuleFor(c => c.text)
                .NotNull()
                .NotEmpty().WithMessage("Комментарий не может быть пустым");
        }
    }
}
