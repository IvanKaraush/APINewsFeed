using APINewsFeed.BLL.DTO.PostDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace APINewsFeed.BLL.Validators.PostValidators
{
    public class UpdatePostDTOValidator : AbstractValidator<UpdatePostDTO>
    {
        public UpdatePostDTOValidator()
        {
            RuleFor(i => i.id)
               .NotNull()
               .NotEmpty().WithMessage("Поле id не может быть пустым");
            RuleFor(i => i.image)
                .Must(IsImageCorrect).WithMessage("Картинка имеет некорректный формат");
        }
        private bool IsImageCorrect(IFormFile image)
        {
            var extensions = new[] { ".jpg", ".png" };
            if (image == null || image?.Length == 0) return true;
            else if (extensions.Contains(Path.GetExtension(image?.FileName))) return true;

            return false;
        }
    }
}
