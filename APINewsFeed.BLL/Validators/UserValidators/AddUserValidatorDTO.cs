using APINewsFeed.BLL.DTO.UserDTOs;
using FluentValidation;

namespace APINewsFeed.BLL.Validators.UserValidators
{
    public class AddUserValidatorDTO : AbstractValidator<UserRegistrationDTO>
    {
        public AddUserValidatorDTO()
        {

            RuleFor(l => l.email)
               .EmailAddress();


        }
    }
}
