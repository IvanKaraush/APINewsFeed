using APINewsFeed.BLL.DTO.FavoritePostDTOs;
using FluentValidation;


namespace APINewsFeed.BLL.Validators.FavoritesPostValidators
{
    public class DeletePostFromFavoritesDTOValidator : AbstractValidator<DeletePostFromFavoritesDTO>
    {
        public DeletePostFromFavoritesDTOValidator()
        {
            RuleFor(p => p.userId)
                    .NotNull()
                    .NotEmpty().WithMessage("Поле userId не может быть пустым");

            RuleFor(p => p.postId)
                .NotNull()
                .NotEmpty().WithMessage("Поле postId не может быть пустым");
        }
    }
}
