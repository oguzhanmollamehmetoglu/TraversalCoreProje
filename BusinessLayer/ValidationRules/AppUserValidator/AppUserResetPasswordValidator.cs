using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.AppUserValidator
{
    public class AppUserResetPasswordValidator : AbstractValidator<AppUserResetPasswordDTO>
    {
        public AppUserResetPasswordValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen şifrenizi giriniz");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Lütfen şifrenizi tekrar giriniz");

            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Şifreler uyumlu değil");
        }
    }
}