using APINewsFeed.BLL.DTO.PostDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace APINewsFeed.BLL.Validators.PostValidators
{
    public class CreatePostDTOValidator : AbstractValidator<CreatePostDTO>
    {
        public CreatePostDTOValidator()
        {
            RuleFor(p => p.image)
                .NotEmpty().WithMessage("Поле image не может быть пустым")
                .Must(IsValideImage).WithMessage("Некорректный формат файла");
        
        }

        private bool IsValideImage(IFormFile image)
        {
            if (image == null || image.Length == 0) return false;

            var extensions = new[] { ".jpg", ".png" };
            return extensions.Contains(Path.GetExtension(image.FileName));
        }
    }
}
