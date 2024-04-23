using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.AppUserValidator
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen adınızı giriniz");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Lütfen soyadınız giriniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Lütfen kullanıcı adını giriniz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen email adresinizi giriniz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen şifreyi giriniz");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Lütfen cinsiyetinizi giriniz");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Lütfen şifreyi tekrar giriniz");

            RuleFor(x => x.SurName).MinimumLength(5).WithMessage("Lütfen en az 5 karakterlik bir veri girişi yapınız");
            RuleFor(x => x.SurName).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakterlik bir veri girişi yapınız");

            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Şifreler uyumlu değil");
        }
    }
}