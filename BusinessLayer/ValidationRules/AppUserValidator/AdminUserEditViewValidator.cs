using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.AppUserValidator
{
    public class AdminUserEditViewValidator : AbstractValidator<AdminUserEditViewDTO>
    {
        public AdminUserEditViewValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("Lütfen isminizi giriniz");
            RuleFor(x => x.surname).NotEmpty().WithMessage("Lütfen soisminizi giriniz");
            RuleFor(x => x.mail).NotEmpty().WithMessage("Lütfen email adresinizi giriniz");
            RuleFor(x => x.phonenumber).NotEmpty().WithMessage("Lütfen telefon numaranızı giriniz");
            RuleFor(x => x.password).NotEmpty().WithMessage("Lütfen şifrenizi giriniz");
            RuleFor(x => x.confirmpassword).NotEmpty().WithMessage("Lütfen şifrenizi tekrar giriniz");
            RuleFor(x => x.ımage).NotEmpty().WithMessage("Lütfen resim seçin");
        }
    }
}