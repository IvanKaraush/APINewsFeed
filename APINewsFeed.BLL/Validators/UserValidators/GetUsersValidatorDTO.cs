using APINewsFeed.BLL.DTO.UserDTOs;
using FluentValidation;

namespace APINewsFeed.BLL.Validators.UserValidators
{
    public class GetUsersValidatorDTO : AbstractValidator<GetUsersDTO>
    {
        public GetUsersValidatorDTO()
        {
            RuleFor(u => u.name)
                .NotNull()
                .NotEmpty().WithMessage("Поле name не может быть пустым");
                
            RuleFor(u => u.pageNumber)
                .NotNull()
                .NotEmpty().WithMessage("Поле pageNumber не может быть пустым");
           
            RuleFor(u => u.pageSize)
               .NotNull()
               .NotEmpty().WithMessage("Поле pageSize не может быть пустым");
        }
    }
}
