using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.AppUserValidator
{
    public class AppUserSinginValidator : AbstractValidator<AppUserSinginDTO>
    {
        public AppUserSinginValidator()
        {
            RuleFor(x => x.username).NotEmpty().WithMessage("Lütfen kullanıcı adınızı giriniz");
            RuleFor(x => x.password).NotEmpty().WithMessage("Lütfen şifrenizi giriniz");
        }
    }
}