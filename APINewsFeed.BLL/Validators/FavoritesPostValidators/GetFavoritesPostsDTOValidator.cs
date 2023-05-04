using APINewsFeed.BLL.DTO.FavoritePostDTOs;
using FluentValidation;


namespace APINewsFeed.BLL.Validators.FavoritesPostValidators
{
    public class GetFavoritesPostsDTOValidator : AbstractValidator<GetFavoritesPostsDTO>
    {
        public GetFavoritesPostsDTOValidator()
        {
            RuleFor(p => p.userId)
                        .NotNull()
                        .NotEmpty().WithMessage("Поле userId не может быть пустым");

            RuleFor(p => p.pageNumber)
                .NotNull()
                .NotEmpty().WithMessage("Поле pageNumber не может быть пустым");

        }
    }
}
